using Wrc.Web.Domain.Replays;

namespace Wrc.Web.Dal.Replays
{
    public class ReplayRecordToReplayTransformer
    {
        private readonly GameInfoBuilderFactory _gameInfoBuilderFactory;

        public ReplayRecordToReplayTransformer(
            GameInfoBuilderFactory gameInfoBuilderFactory)
        {
            _gameInfoBuilderFactory = gameInfoBuilderFactory;
        }

        public Replay ToReplay(ReplayRecord replay)
        {
            var gameInfoBuilder = _gameInfoBuilderFactory.GetBuilder(replay.Version)
                .SetIsNetworkMode(replay.IsNetworkMode)
                .SetGameMode(replay.GameModeCode)
                .SetMap(replay.GameMapCode)
                .SetMaxPlayers(replay.MaxPlayers)
                .SetAI(replay.AI)
                .SetGameType(replay.GameTypeCode)
                .SetIsPrivate(replay.IsPrivate)
                .SetInitMoney(replay.InitMoney)
                .SetScoreLimit(replay.ScoreLimit)
                .SetServerName(replay.ServerName)
                .SetVictoryCondition(replay.VictoryConditionCode)
                .SetNationConstraint(replay.NationConstraint)
                .SetThematicConstraint(replay.ThematicConstraint)
                .SetDateConstraint(replay.DateConstraint)
                .SetIncomeRate(replay.IncomeRate)
                .SetAllowObservers(replay.AllowObservers)
                .SetSeed(replay.Seed);

            foreach (var playerDto in replay.Players)
            {
                var playerInfo = ToPlayerInfo(playerDto);
                gameInfoBuilder.AddPlayerInfo(playerInfo);
            }

            return new Replay(
                replay.Id,
                replay.Title,
                gameInfoBuilder.Build(),
                new UploadedFile(replay.FileLink, replay.FileHash, replay.UploadedAt),
                replay.DownloadCount);
        }

        private static PlayerInfo ToPlayerInfo(PlayerRecord player)
        {
            return new PlayerInfo(
                player.Id,
                new AccountInfo(player.AccountRecord.Id, player.AccountRecord.Name),
                player.Elo,
                player.Rank,
                player.Level,
                player.Name,
                player.TeamName,
                player.Avatar,
                player.IALevel,
                player.WasReady,
                player.DeckName,
                player.DeckContent,
                player.Alliance,
                player.IsEnteredInLobby,
                player.ScoreLimit,
                player.IncomeRate,
                player.Number);
        }
    }
}