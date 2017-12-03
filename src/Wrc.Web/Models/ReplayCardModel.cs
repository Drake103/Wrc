using System;
using System.Collections.Generic;
using System.Linq;
using Wrc.Web.Domain.Replays;

namespace Wrc.Web.Models
{
    public class ReplayCardModel
    {
        private ReplayCardModel(
            int id,
            DateTime uploadedAt,
            string title,
            int playersCount,
            string mapName,
            string victoryConditionName,
            string gameVersion,
            int downloadCount,
            IEnumerable<AllianceModel> allianceModels)
        {
            Id = id;
            UploadedAt = uploadedAt;
            Title = title;
            PlayersCount = playersCount;
            MapName = mapName;
            VictoryConditionName = victoryConditionName;
            GameVersion = gameVersion;
            DownloadCount = downloadCount;

            Alliances = allianceModels.ToArray();
        }

        public int Id { get; }

        public DateTime UploadedAt { get; }

        public string Title { get; }

        public int PlayersCount { get; }

        public string MapName { get; }

        public string VictoryConditionName { get; }

        public string GameVersion { get; }

        public int DownloadCount { get; }

        public IReadOnlyList<AllianceModel> Alliances { get; }

        public static ReplayCardModel FromReplay(Replay replay)
        {
            var alliances = replay.GameInfo.Players
                .GroupBy(p => p.Alliance)
                .Select(g => new AllianceModel(g.Key, g.Select(PlayerModel.CreateFrom)));

            return new ReplayCardModel(
                replay.Id,
                replay.UploadedFile.UploadedAt,
                replay.Title,
                replay.GameInfo.Players.Count,
                replay.GameInfo.GameMap.Name,
                replay.GameInfo.VictoryCondition.Name,
                replay.GameInfo.Version,
                replay.DownloadCount,
                alliances);
        }
    }
}