using System;
using Wrc.Web.Domain.Replays.Dictionaries;

namespace Wrc.Web.Domain.Replays
{
    public class LightReplay
    {
        public LightReplay(
            int id,
            string title,
            DateTime uploadedAt,
            int playersCount,
            IGameMap map,
            IVictoryCondition victoryCondition,
            string gameVersion,
            int downloadsCounter)
        {
            Id = id;
            Title = title;
            UploadedAt = uploadedAt;
            PlayersCount = playersCount;
            Map = map;
            VictoryCondition = victoryCondition;
            GameVersion = gameVersion;
            DownloadsCounter = downloadsCounter;
        }

        public int Id { get; }

        public DateTime UploadedAt { get; }

        public string Title { get; }

        public int PlayersCount { get; }

        public IGameMap Map { get; }

        public IVictoryCondition VictoryCondition { get; }

        public string GameVersion { get; }

        public int DownloadsCounter { get; }
    }
}