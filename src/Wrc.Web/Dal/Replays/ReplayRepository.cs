using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wrc.Domain.Dtos;
using Wrc.Domain.Dtos.Replays;
using Wrc.Web.Dal.Repositories;
using Wrc.Web.Domain.Replays;
using Wrc.Web.Dtos;
using Wrc.Web.Dtos.Replays;

namespace Wrc.Web.Dal.Replays
{
    public class ReplayRepository : IReplayRepository
    {
        private WrcContext _ctx;

        public ReplayRepository(WrcContext dbContext)
        {
            _ctx = dbContext;
        }

        public Task<IReadOnlyList<ReplayRowDto>> ListAsync(PagingInfo pagingInfo, string searchText)
        {
            var query = _ctx.Replays;

            var orderedQuery = FilterBySearchText(query, searchText).OrderByDescending(x => x.UploadDate);

            return FetchAsync(orderedQuery, pagingInfo);
        }

        public IReadOnlyList<ReplayRowDto> GetByPlayerUser(int playerUserId, PagingInfo pagingInfo)
        {
            throw new NotImplementedException();
            /*var query = from replay in _crud.Get()
                from player in replay.Players
                where player.PlayerUser.Id == playerUserId
                select replay;

            query = query.OrderByDescending(x => x.UploadDate);

            return Fetch(query, pagingInfo);*/
        }

        public ReplayCardDto GetReplayCard(int replayId)
        {
            throw new NotImplementedException();
            /*var query = from replay in _crud.Get()
                where replay.Id == replayId
                select replay;

            var replayCardDto = query.Select(x => new ReplayCardDto
            {
                Id = x.Id,
                UploadDate = x.UploadDate,
                PlayersCount = x.Players.Count(),
                MapName = x.GameMap.Name,
                Title = x.Title,
                VictoryConditionName = x.VictoryCondition.Name,
                GameVersion = x.Version,
                ScoreLimit = x.ScoreLimit,
                DownloadsCounter = x.DownloadsCounter
            }).SingleOrDefault();

            if (replayCardDto == null)
                throw new NotSupportedException("ReplayNotFound");

            replayCardDto.Alliances = new List<AllianceDto>();

            var alliancePlayers = (from replay in query
                from p in replay.Players
                select new PlayerDto
                {
                    Id = p.Id,
                    PlayerUserId = p.PlayerUser.Id,
                    PlayerElo = p.PlayerElo,
                    PlayerRank = p.PlayerRank,
                    PlayerLevel = p.PlayerLevel,
                    PlayerName = p.PlayerName,
                    PlayerTeamName = p.PlayerTeamName,
                    PlayerAvatar = p.PlayerAvatar,
                    PlayerIALevel = p.PlayerIALevel,
                    PlayerReady = p.PlayerReady,
                    PlayerDeckName = p.PlayerDeckName,
                    PlayerDeckContent = p.PlayerDeckContent,
                    PlayerAlliance = p.PlayerAlliance,
                    PlayerIsEnteredInLobby = p.PlayerIsEnteredInLobby,
                    PlayerScoreLimit = p.PlayerScoreLimit,
                    PlayerIncomeRate = p.PlayerIncomeRate
                }).ToList().GroupBy(x => x.PlayerAlliance);

            foreach (var groupedByAlliance in alliancePlayers)
            {
                var players = groupedByAlliance.ToList();
                players.ForEach(x =>
                {
                    x.PlayerElo = Math.Round(x.PlayerElo);
                    x.DeckInfo = DeckContentHelper.GetDeckInfo(x.PlayerDeckContent);
                }); // round ELO
                replayCardDto.Alliances.Add(new AllianceDto(players));
            }

            return replayCardDto;*/
        }

        public int GetTotalCount(string searchText)
        {
            throw new NotImplementedException();
            /*var query = _crud.Get();
            query = FilterBySearchText(query, searchText);
            return query.Count();*/
        }

        public bool IsAlreadyUploaded(Guid fileHash, out string title)
        {
            throw new NotImplementedException();
            /*title = null;
            var replay = _crud.Get().FirstOrDefault(x => x.FileHash == fileHash);
            if (replay == null) return false;

            title = replay.Title;
            return true;*/
        }

        public void Add(Replay replay)
        {
            _ctx.Replays.Add(replay);
        }

        private static IQueryable<Replay> FilterBySearchText(IQueryable<Replay> query, string searchText)
        {
            if (string.IsNullOrWhiteSpace(searchText)) return query;

            searchText = searchText.ToLowerInvariant();

            return query.Where(x => x.GameMap.Name.ToLowerInvariant().Contains(searchText)
                                    || x.ServerName.ToLowerInvariant().Contains(searchText)
                                    || x.Title.ToLowerInvariant().Contains(searchText));
        }

        private static IList<ReplayRowDto> Fetch(IQueryable<Replay> query, PagingInfo pagingInfo)
        {
            var dtoQuery = query.Select(x => new ReplayRowDto
            {
                Id = x.Id,
                UploadDate = x.UploadDate,
                PlayersCount = x.Players.Count(),
                MapName = x.GameMap.Name,
                Title = x.Title,
                VictoryConditionName = x.VictoryCondition.Name,
                GameVersion = x.Version
            });

            if (pagingInfo == PagingInfo.All)
                return dtoQuery.ToList();

            return dtoQuery.Skip(pagingInfo.StartIndex).Take(pagingInfo.PageSize).ToList();
        }

        private static async Task<IReadOnlyList<ReplayRowDto>> FetchAsync(IQueryable<Replay> query, PagingInfo pagingInfo)
        {
            var dtoQuery = query.Select(x => new ReplayRowDto
            {
                Id = x.Id,
                UploadDate = x.UploadDate,
                PlayersCount = x.Players.Count(),
                MapName = x.GameMap.Name,
                Title = x.Title,
                VictoryConditionName = x.VictoryCondition.Name,
                GameVersion = x.Version
            });

            if (pagingInfo == PagingInfo.All)
                return await dtoQuery.ToListAsync();

            return await dtoQuery.Skip(pagingInfo.StartIndex).Take(pagingInfo.PageSize).ToListAsync();
        }

    }
}