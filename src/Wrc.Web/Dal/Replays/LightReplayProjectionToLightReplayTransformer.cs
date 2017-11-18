using Wrc.Web.Domain.Replays;
using Wrc.Web.Domain.Replays.Dictionaries;

namespace Wrc.Web.Dal.Replays
{
    public class LightReplayProjectionToLightReplayTransformer
    {
        private readonly IDictionaryItemStorage<IGameMap> _gameMapStorage;
        private readonly IDictionaryItemStorage<IVictoryCondition> _victoryConditionStorage;

        public LightReplayProjectionToLightReplayTransformer(
            IDictionaryItemStorage<IGameMap> gameMapStorage,
            IDictionaryItemStorage<IVictoryCondition> victoryConditionStorage)
        {
            _gameMapStorage = gameMapStorage;
            _victoryConditionStorage = victoryConditionStorage;
        }

        public LightReplay ToLightReplay(LightReplayProjection lightReplayProjection)
        {
            return new LightReplay(
                lightReplayProjection.Id,
                lightReplayProjection.Title,
                lightReplayProjection.UploadedAt,
                lightReplayProjection.PlayersCount,
                _gameMapStorage.GetItemOrDefault(lightReplayProjection.MapPublicCode),
                _victoryConditionStorage.GetItemOrDefault(lightReplayProjection.VictoryConditionPublicCode),
                lightReplayProjection.GameVersion,
                lightReplayProjection.DownloadsCounter);
        }
    }
}