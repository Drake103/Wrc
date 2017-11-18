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
                .SetAI(replay.Ai)
                .SetGameType(replay.GameTypeCode)
                .SetIsPrivate(replay.Private)
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
                new UploadedFile(replay.FileLink, replay.FileHash, replay.UploadedAt));
        }

        private static PlayerInfo ToPlayerInfo(PlayerRecord player)
        {
            return new PlayerInfo(
                player.Id,
                new AccountInfo(player.AccountRecord.Id, player.AccountRecord.Name),
                player.PlayerElo,
                player.PlayerRank,
                player.PlayerLevel,
                player.PlayerName,
                player.PlayerTeamName,
                player.PlayerAvatar,
                player.PlayerIALevel,
                player.PlayerReady,
                player.PlayerDeckName,
                player.PlayerDeckContent,
                player.PlayerAlliance,
                player.PlayerIsEnteredInLobby,
                player.PlayerScoreLimit,
                player.PlayerIncomeRate,
                player.PlayerNumber);
        }
    }
}