using System;
using Wrc.Web.Domain.Replays;

namespace Wrc.Web.Models
{
    public class ReplayRowModel
    {
        private readonly LightReplay _lightReplay;

        public ReplayRowModel(LightReplay lightReplay)
        {
            _lightReplay = lightReplay;
        }

        public int Id => _lightReplay.Id;

        public DateTime UploadedAt => _lightReplay.UploadedAt;

        public string Title => _lightReplay.Title;

        public int PlayersCount => _lightReplay.PlayersCount;

        public string MapName => _lightReplay.Map.Name;

        public string VictoryConditionName => _lightReplay.VictoryCondition.Name;

        public string GameVersion => _lightReplay.GameVersion;

        public int DownloadCount => _lightReplay.DownloadCount;
    }
}