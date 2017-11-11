using System;

namespace Wrc.Web.Dtos.Replays
{
    public class ReplayRowDto
    {
        public int Id { get; set; }
        public DateTime UploadDate { get; set; }
        public string Title { get; set; }
        public int PlayersCount { get; set; }
        public string MapName { get; set; }

        public string VictoryConditionName { get; set; }
        public string VictoryConditionPublicCode { get; set; }

        public string GameVersion { get; set; }
        public int DownloadsCounter { get; set; }
    }
}