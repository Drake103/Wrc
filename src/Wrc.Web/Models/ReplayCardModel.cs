using System;
using Wrc.Web.Domain.Replays;

namespace Wrc.Web.Models
{
    public class ReplayCardModel
    {
        private readonly Replay _replay;

        public ReplayCardModel(Replay replay)
        {
            _replay = replay;
        }

        public int Id => _replay.Id;

        public DateTime UploadedAt => _replay.UploadedFile.UploadedAt;

        public string Title => _replay.Title;

        public int PlayersCount => _replay.GameInfo.Players.Count;

        public string MapName => _replay.GameInfo.GameMap.Name;

        public string VictoryConditionName => _replay.GameInfo.VictoryCondition.Name;

        public string GameVersion => _replay.GameInfo.Version;

        public int DownloadCount => _replay.DownloadCount;
    }
}