using Wrc.Web.Dal.Replays;
using Wrc.Web.Domain.Replays.Dictionaries;

namespace Wrc.Web.Domain.Replays
{
    public class GameInfoBuilderFactory
    {
        private readonly IDictionaryItemStorage<IGameMap> _gameMapStorage;
        private readonly IDictionaryItemStorage<IGameMode> _gameModeStorage;
        private readonly IDictionaryItemStorage<IGameType> _gameTypeStorage;
        private readonly IDictionaryItemStorage<IVictoryCondition> _victoryConditionStorage;

        public GameInfoBuilderFactory(
            IDictionaryItemStorage<IGameMode> gameModeStorage,
            IDictionaryItemStorage<IGameType> gameTypeStorage,
            IDictionaryItemStorage<IGameMap> gameMapStorage,
            IDictionaryItemStorage<IVictoryCondition> victoryConditionStorage)
        {
            _gameModeStorage = gameModeStorage;
            _gameTypeStorage = gameTypeStorage;
            _gameMapStorage = gameMapStorage;
            _victoryConditionStorage = victoryConditionStorage;
        }

        public GameInfoBuilder GetBuilder(string version)
        {
            return new GameInfoBuilder(
                version,
                _gameModeStorage,
                _gameTypeStorage,
                _gameMapStorage,
                _victoryConditionStorage);
        }
    }
}