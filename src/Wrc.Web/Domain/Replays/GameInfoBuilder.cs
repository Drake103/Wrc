using System.Collections.Generic;
using Wrc.Web.Dal.Replays;
using Wrc.Web.Domain.Replays.Dictionaries;

namespace Wrc.Web.Domain.Replays
{
    public class GameInfoBuilder
    {
        private readonly string _version;
        private readonly IDictionaryItemStorage<IGameMode> _gameModeStorage;
        private readonly IDictionaryItemStorage<IGameType> _gameTypeStorage;
        private readonly IDictionaryItemStorage<IGameMap> _gameMapStorage;
        private readonly IDictionaryItemStorage<IVictoryCondition> _victoryConditionStorage;
        private bool _isNetworkMode;
        private string _gameModeCode;
        private string _gameMapCode;
        private int _maxPlayers;
        private bool _ai;
        private string _gameTypeCode;
        private bool _isPrivate;
        private int _initMoney;
        private int _scoreLimit;
        private string _serverName;
        private string _victoryConditionCode;
        private string _nationConstraint;
        private string _thematicConstraint;
        private string _dateConstraint;
        private int _incomeRate;
        private bool _allowObservers;
        private string _seed;
        private readonly List<PlayerInfo> _playerInfos = new List<PlayerInfo>();

        public GameInfoBuilder(
            string version,
            IDictionaryItemStorage<IGameMode> gameModeStorage,
            IDictionaryItemStorage<IGameType> gameTypeStorage,
            IDictionaryItemStorage<IGameMap> gameMapStorage,
            IDictionaryItemStorage<IVictoryCondition> victoryConditionStorage)
        {
            _version = version;
            _gameModeStorage = gameModeStorage;
            _gameTypeStorage = gameTypeStorage;
            _gameMapStorage = gameMapStorage;
            _victoryConditionStorage = victoryConditionStorage;
        }

        public GameInfoBuilder SetIsNetworkMode(bool isNetworkMode)
        {
            _isNetworkMode = isNetworkMode;
            return this;
        }

        public GameInfoBuilder SetGameMode(string gameModeCode)
        {
            _gameModeCode = gameModeCode;
            return this;
        }

        public GameInfoBuilder SetMap(string gameMapCode)
        {
            _gameMapCode = gameMapCode;
            return this;
        }

        public GameInfoBuilder SetMaxPlayers(int maxPlayers)
        {
            _maxPlayers = maxPlayers;
            return this;
        }

        public GameInfo Build()
        {
            return new GameInfo(
                _version,
                _isNetworkMode,
                _gameModeStorage.GetItemOrDefault(_gameModeCode),
                _gameMapStorage.GetItemOrDefault(_gameMapCode),
                _gameTypeStorage.GetItemOrDefault(_gameTypeCode),
                _victoryConditionStorage.GetItemOrDefault(_victoryConditionCode),
                _maxPlayers,
                _ai,
                _isPrivate,
                _initMoney,
                _scoreLimit,
                _serverName,
                _nationConstraint,
                _thematicConstraint,
                _dateConstraint,
                _incomeRate,
                _allowObservers,
                _seed,
                _playerInfos);
        }

        public GameInfoBuilder SetAI(bool ai)
        {
            _ai = ai;
            return this;
        }

        public GameInfoBuilder SetGameType(string gameTypeCode)
        {
            _gameTypeCode = gameTypeCode;
            return this;
        }

        public GameInfoBuilder SetIsPrivate(bool isPrivate)
        {
            _isPrivate = isPrivate;
            return this;
        }

        public GameInfoBuilder SetInitMoney(int initMoney)
        {
            _initMoney = initMoney;
            return this;
        }

        public GameInfoBuilder SetScoreLimit(int scoreLimit)
        {
            _scoreLimit = scoreLimit;
            return this;
        }

        public GameInfoBuilder SetServerName(string serverName)
        {
            _serverName = serverName;
            return this;
        }

        public GameInfoBuilder SetVictoryCondition(string victoryConditionCode)
        {
            _victoryConditionCode = victoryConditionCode;
            return this;
        }

        public GameInfoBuilder SetNationConstraint(string nationConstraint)
        {
            _nationConstraint = nationConstraint;
            return this;
        }

        public GameInfoBuilder SetThematicConstraint(string thematicConstraint)
        {
            _thematicConstraint = thematicConstraint;
            return this;
        }

        public GameInfoBuilder SetDateConstraint(string dateConstraint)
        {
            _dateConstraint = dateConstraint;
            return this;
        }

        public GameInfoBuilder SetIncomeRate(int incomeRate)
        {
            _incomeRate = incomeRate;
            return this;
        }

        public GameInfoBuilder SetAllowObservers(bool allowObservers)
        {
            _allowObservers = allowObservers;
            return this;
        }

        public GameInfoBuilder SetSeed(string seed)
        {
            _seed = seed;
            return this;
        }

        public GameInfoBuilder AddPlayerInfo(PlayerInfo playerInfo)
        {
            _playerInfos.Add(playerInfo);
            return this;
        }
    }
}