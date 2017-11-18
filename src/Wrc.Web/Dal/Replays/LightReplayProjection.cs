using System;

namespace Wrc.Web.Dal.Replays
{
    public class LightReplayProjection
    {
        public int Id { get; set; }
        public DateTime UploadedAt { get; set; }
        public string Title { get; set; }
        public int PlayersCount { get; set; }

        public string MapPublicCode { get; set; }

        public string VictoryConditionPublicCode { get; set; }

        public string GameVersion { get; set; }
        public int DownloadsCounter { get; set; }
    }
}