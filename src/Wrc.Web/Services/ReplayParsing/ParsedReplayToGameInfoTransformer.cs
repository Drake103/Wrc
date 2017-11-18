using System;
using Wrc.Web.Domain.Replays;
using Wrc.Web.Dtos.ReplayParsing;

namespace Wrc.Web.Services.ReplayParsing
{
    public class ParsedReplayToGameInfoTransformer : IParsedReplayToGameInfoTransformer
    {
        private readonly GameInfoBuilderFactory _gameInfoBuilderFactory;

        public ParsedReplayToGameInfoTransformer(
            GameInfoBuilderFactory gameInfoBuilderFactory)
        {
            _gameInfoBuilderFactory = gameInfoBuilderFactory;
        }

        public IGameInfo ToGameInfo(ReplayParsedDto parsed)
        {
            var gameInfoBuilder = _gameInfoBuilderFactory.GetBuilder(parsed.Version)
                .SetIsNetworkMode(Convert.ToBoolean(parsed.IsNetworkMode))
                .SetGameMode(parsed.GameMode)
                .SetMap(parsed.Map)
                .SetMaxPlayers(parsed.NbMaxPlayer)
                .SetAI(Convert.ToBoolean(parsed.NbAI))
                .SetGameType(parsed.GameType)
                .SetIsPrivate(Convert.ToBoolean(parsed.Private))
                .SetInitMoney(parsed.InitMoney)
                .SetScoreLimit(parsed.ScoreLimit)
                .SetServerName(parsed.ServerName)
                .SetVictoryCondition(parsed.VictoryCond)
                .SetNationConstraint(parsed.NationConstraint ?? "0")
                .SetThematicConstraint(parsed.ThematicConstraint ?? "0")
                .SetDateConstraint(parsed.DateConstraint ?? "0")
                .SetIncomeRate(int.Parse(parsed.IncomeRate))
                .SetAllowObservers(Convert.ToBoolean(parsed.AllowNbObs))
                .SetSeed(parsed.Seed);

            foreach (var playerDto in parsed.Players)
            {
                var playerInfo = ToPlayerInfo(playerDto);
                gameInfoBuilder.AddPlayerInfo(playerInfo);
            }

            return gameInfoBuilder.Build();
        }

        private static PlayerInfo ToPlayerInfo(PlayerParsedDto dto)
        {
            return new PlayerInfo(
                0,
                new AccountInfo(dto.PlayerEugenId, dto.PlayerName),
                dto.PlayerElo,
                dto.PlayerRank,
                dto.PlayerLevel,
                dto.PlayerName,
                dto.PlayerTeamName,
                dto.PlayerAvatar,
                dto.PlayerIALevel,
                Convert.ToBoolean(dto.PlayerReady),
                dto.PlayerDeckName,
                dto.PlayerDeckContent,
                dto.PlayerAlliance,
                Convert.ToBoolean(dto.PlayerIsEnteredInLobby),
                dto.PlayerScoreLimit,
                dto.PlayerIncomeRate,
                dto.PlayerNumber);
        }
    }
}