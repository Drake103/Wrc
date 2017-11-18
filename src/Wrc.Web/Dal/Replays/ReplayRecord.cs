using System;
using System.Collections.Generic;

namespace Wrc.Web.Dal.Replays
{
    public class ReplayRecord
    {
        public int Id { get; set; }

        public string Title { get; set; }
        public bool IsNetworkMode { get; set; }
        public string Version { get; set; }
        public string GameModeCode { get; set; }
        public string GameMapCode { get; set; }
        public int MaxPlayers { get; set; }
        public bool AI { get; set; }
        public string GameTypeCode { get; set; }
        public bool IsPrivate { get; set; }
        public int InitMoney { get; set; }
        public int ScoreLimit { get; set; }
        public string ServerName { get; set; }
        public string VictoryConditionCode { get; set; }
        public string NationConstraint { get; set; }
        public string ThematicConstraint { get; set; }
        public string DateConstraint { get; set; }
        public int IncomeRate { get; set; }
        public bool AllowObservers { get; set; }
        public string Seed { get; set; }

        public DateTime UploadedAt { get; set; }
        public string FileName { get; set; }
        public string FileHash { get; set; }

        public int DownloadCount { get; set; }

        public IList<PlayerRecord> Players { get; set; } = new List<PlayerRecord>();
    }
}