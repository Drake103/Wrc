using System;
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
            int scoreLimit,
            BlueforModel bluefor,
            RedforModel redfor)
        {
            Id = id;
            UploadedAt = uploadedAt;
            Title = title;
            PlayersCount = playersCount;
            MapName = mapName;
            VictoryConditionName = victoryConditionName;
            GameVersion = gameVersion;
            DownloadCount = downloadCount;
            ScoreLimit = scoreLimit;
            Bluefor = bluefor;
            Redfor = redfor;
        }

        public int Id { get; }

        public DateTime UploadedAt { get; }

        public string Title { get; }

        public int PlayersCount { get; }

        public string MapName { get; }

        public string VictoryConditionName { get; }

        public string GameVersion { get; }

        public int DownloadCount { get; }

        public int ScoreLimit { get; }

        public BlueforModel Bluefor { get; }

        public RedforModel Redfor { get; }

        public static ReplayCardModel FromReplay(Replay replay)
        {
            return new ReplayCardModel(
                replay.Id,
                replay.UploadedFile.UploadedAt,
                replay.Title,
                replay.GameInfo.Players.Count,
                replay.GameInfo.GameMap.Name,
                replay.GameInfo.VictoryCondition.Name,
                replay.GameInfo.Version,
                replay.DownloadCount,
                replay.GameInfo.ScoreLimit,
                BlueforModel.CreateFrom(replay.GameInfo.Players),
                RedforModel.CreateFrom(replay.GameInfo.Players));
        }
    }
}