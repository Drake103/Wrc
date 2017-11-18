using System.Collections.Generic;
using System.Linq;
using Wrc.Web.Domain.Replays.Dictionaries;

namespace Wrc.Web.Domain.Replays
{
    public class GameInfo : IGameInfo
    {
        public GameInfo(
            string version,
            bool isNetworkMode,
            IGameMode gameMode,
            IGameMap gameMap,
            IGameType gameType,
            IVictoryCondition victoryCondition,
            int maxPlayers,
            bool ai,
            bool isPrivate,
            int initMoney,
            int scoreLimit,
            string serverName,
            string nationConstraint,
            string thematicConstraint,
            string dateConstraint,
            int incomeRate,
            bool allowObservers,
            string seed,
            IEnumerable<PlayerInfo> players)
        {
            Version = version;
            IsNetworkMode = isNetworkMode;
            GameMode = gameMode;
            GameMap = gameMap;
            GameType = gameType;
            VictoryCondition = victoryCondition;
            MaxPlayers = maxPlayers;
            AI = ai;
            IsPrivate = isPrivate;
            InitMoney = initMoney;
            ScoreLimit = scoreLimit;
            ServerName = serverName;
            NationConstraint = nationConstraint;
            ThematicConstraint = thematicConstraint;
            DateConstraint = dateConstraint;
            IncomeRate = incomeRate;
            AllowObservers = allowObservers;
            Seed = seed;
            Players = players.ToList();
        }

        public bool IsNetworkMode { get; }

        public string Version { get; }

        public IGameMode GameMode { get; }

        public IGameMap GameMap { get; }

        public IGameType GameType { get; }

        public IVictoryCondition VictoryCondition { get; }

        public int MaxPlayers { get; }

        public bool AI { get; }

        public bool IsPrivate { get; }

        public int InitMoney { get; }

        public int ScoreLimit { get; }

        public string ServerName { get; }

        public string NationConstraint { get; }

        public string ThematicConstraint { get; }

        public string DateConstraint { get; }

        public int IncomeRate { get; }

        public bool AllowObservers { get; }

        public string Seed { get; }

        public IReadOnlyList<PlayerInfo> Players { get; }
    }
}