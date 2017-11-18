using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Wrc.Web.Domain.Replays;
using Wrc.Web.Dtos;

namespace Wrc.Web.Dal.Replays
{
    public class ReplayRepository : IReplayRepository
    {
        private readonly LightReplayProjectionToLightReplayTransformer _lightReplayProjectionToLightReplayTransformer;
        private readonly ReplayRecordToReplayTransformer _replayRecordToReplayTransformer;
        private readonly WrcContext _wrcContext;

        public ReplayRepository(
            WrcContext wrcContext,
            LightReplayProjectionToLightReplayTransformer lightReplayProjectionToLightReplayTransformer,
            ReplayRecordToReplayTransformer replayRecordToReplayTransformer)
        {
            _wrcContext = wrcContext;
            _lightReplayProjectionToLightReplayTransformer = lightReplayProjectionToLightReplayTransformer;
            _replayRecordToReplayTransformer = replayRecordToReplayTransformer;
        }

        public async Task<IReadOnlyList<LightReplay>> ListAsync(PagingInfo pagingInfo, string searchText)
        {
            IQueryable<ReplayRecord> query = _wrcContext.Replays;

            query = FilterBySearchText(query, searchText).OrderByDescending(r => r.UploadedAt);

            query = query.Skip(pagingInfo.Start).Take(pagingInfo.Limit);

            var lightReplayProjections = await ToLightReplayProjection(query).ToListAsync().ConfigureAwait(false);

            return lightReplayProjections
                .Select(_lightReplayProjectionToLightReplayTransformer.ToLightReplay)
                .ToList();
        }

        public async Task<IReadOnlyList<LightReplay>> GetByAccountAsync(int accountId, PagingInfo pagingInfo)
        {
            IQueryable<ReplayRecord> query = _wrcContext.Replays;

            query = from replay in query
                from player in replay.Players
                where player.AccountRecord.Id == accountId
                select replay;

            query = query.OrderBy(r => r.UploadedAt);

            query = query.Skip(pagingInfo.Start).Take(pagingInfo.Limit);

            var lightReplayProjections = await ToLightReplayProjection(query).ToListAsync().ConfigureAwait(false);

            return lightReplayProjections
                .Select(_lightReplayProjectionToLightReplayTransformer.ToLightReplay)
                .ToList();
        }

        public async Task<Replay> GetReplayAsync(int replayId)
        {
            var replay = await _wrcContext.FindAsync<ReplayRecord>(replayId);
            if (replay == null)
                return null;

            foreach (var navigationEntry in _wrcContext.Entry(replay).Navigations)
                await navigationEntry.LoadAsync();

            return _replayRecordToReplayTransformer.ToReplay(replay);
        }

        public Task<int> GetTotalCountAsync(string searchText)
        {
            var filteredQuery = FilterBySearchText(_wrcContext.Replays, searchText);
            return filteredQuery.CountAsync();
        }

        public async Task<Replay> GetByFileHashAsync(string fileHash)
        {
            var replay = await _wrcContext.Replays.FirstOrDefaultAsync(x => x.FileHash == fileHash);

            if (replay == null)
                return null;

            foreach (var navigationEntry in _wrcContext.Entry(replay).Navigations)
                await navigationEntry.LoadAsync();

            return _replayRecordToReplayTransformer.ToReplay(replay);
        }

        public void Add(Replay replayRecord)
        {
            throw new NotImplementedException();
        }

        private static IQueryable<LightReplayProjection> ToLightReplayProjection(IQueryable<ReplayRecord> query)
        {
            return query.Select(
                r => new LightReplayProjection
                {
                    Id = r.Id,
                    UploadedAt = r.UploadedAt,
                    PlayersCount = r.Players.Count,
                    MapPublicCode = r.GameMapCode,
                    Title = r.Title,
                    VictoryConditionPublicCode = r.VictoryConditionCode,
                    GameVersion = r.Version
                });
        }

        private static IQueryable<ReplayRecord> FilterBySearchText(IQueryable<ReplayRecord> query, string searchText)
        {
            if (string.IsNullOrWhiteSpace(searchText))
                return query;

            searchText = searchText.ToLowerInvariant();

            return query.Where(
                x => x.ServerName.ToLowerInvariant().Contains(searchText)
                     || x.Title.ToLowerInvariant().Contains(searchText));
        }
    }
}