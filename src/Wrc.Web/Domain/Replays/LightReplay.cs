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
            int downloadCount)
        {
            Id = id;
            Title = title;
            UploadedAt = uploadedAt;
            PlayersCount = playersCount;
            Map = map;
            VictoryCondition = victoryCondition;
            GameVersion = gameVersion;
            DownloadCount = downloadCount;
        }

        public int Id { get; }

        public DateTime UploadedAt { get; }

        public string Title { get; }

        public int PlayersCount { get; }

        public IGameMap Map { get; }

        public IVictoryCondition VictoryCondition { get; }

        public string GameVersion { get; }

        public int DownloadCount { get; }
    }
}