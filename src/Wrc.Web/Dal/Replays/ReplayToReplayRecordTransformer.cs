using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Wrc.Web.Domain.Replays;

namespace Wrc.Web.Dal.Replays
{
    public class ReplayToReplayRecordTransformer
    {
        private readonly WrcContext _wrcContext;

        public ReplayToReplayRecordTransformer(WrcContext wrcContext)
        {
            _wrcContext = wrcContext;
        }

        public async Task<ReplayRecord> ToReplayRecordAsync(Replay replay)
        {
            if (replay.Id != 0)
            {
                throw new ArgumentException("Currently only new replays can be converted");
            }

            var gameInfo = replay.GameInfo;

            var playerRecords = new List<PlayerRecord>();

            foreach (var playerInfo in replay.GameInfo.Players)
            {
                var playerRecord = await ToPlayerRecordAsync(playerInfo).ConfigureAwait(false);

                playerRecords.Add(playerRecord);
            }

            return new ReplayRecord
            {
                Title = replay.Title,

                Version = gameInfo.Version,
                IsNetworkMode = gameInfo.IsNetworkMode,
                GameModeCode = gameInfo.GameMode.PublicCode,
                GameMapCode = gameInfo.GameMap.PublicCode,
                GameTypeCode = gameInfo.GameType.PublicCode,
                VictoryConditionCode = gameInfo.VictoryCondition.PublicCode,
                MaxPlayers = gameInfo.MaxPlayers,
                AI = gameInfo.AI,
                IsPrivate = gameInfo.IsPrivate,
                InitMoney = gameInfo.InitMoney,
                ScoreLimit = gameInfo.ScoreLimit,
                ServerName = gameInfo.ServerName,
                NationConstraint = gameInfo.NationConstraint,
                ThematicConstraint = gameInfo.ThematicConstraint,
                DateConstraint = gameInfo.ThematicConstraint,
                IncomeRate = gameInfo.IncomeRate,
                AllowObservers = gameInfo.AllowObservers,
                Seed = gameInfo.Seed,

                UploadedAt = replay.UploadedFile.UploadedAt
            };
        }

        private async Task<PlayerRecord> ToPlayerRecordAsync(PlayerInfo p)
        {
            var accountRecord = await _wrcContext.Accounts
                .FirstOrDefaultAsync(a => a.EugenUserId == p.AccountInfo.EugenUserId)
                .ConfigureAwait(false);

            if (accountRecord == null)
            {
                accountRecord = new AccountRecord
                {
                    EugenUserId = p.AccountInfo.EugenUserId,
                    Name = p.AccountInfo.Name
                };
            }

            return new PlayerRecord
            {
                AccountRecord = accountRecord,
                Elo = p.Elo,
                Rank = p.Rank,
                Level = p.Level,
                Name = p.Name,
                TeamName = p.TeamName,
                Avatar = p.Avatar,
                IALevel = p.IALevel,
                WasReady = p.WasReady,
                DeckName = p.DeckName,
                DeckContent = p.DeckContent,
                Alliance = p.Alliance,
                IsEnteredInLobby = p.IsEnteredInLobby,
                ScoreLimit = p.ScoreLimit,
                IncomeRate = p.IncomeRate,
                Number = p.Number
            };
        }
    }
}