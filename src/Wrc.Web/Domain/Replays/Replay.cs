using System;
using System.Collections.Generic;
using Wrc.Web.Domain.Replays.Dictionaries;

namespace Wrc.Web.Domain.Replays
{
    public class Replay
    {
        public int Id { get; set; }

        public string Title { get; set; }
        public bool IsNetworkMode { get; set; }
        public string Version { get; set; }
        public GameMode GameMode { get; set; }
        public GameMap GameMap { get; set; }
        public int MaxPlayers { get; set; }
        public bool AI { get; set; }
        public GameType GameType { get; set; }
        public bool Private { get; set; }
        public int InitMoney { get; set; }
        public int ScoreLimit { get; set; }
        public string ServerName { get; set; }
        public VictoryCondition VictoryCondition { get; set; }
        public string NationConstraint { get; set; }
        public string ThematicConstraint { get; set; }
        public string DateConstraint { get; set; }
        public int IncomeRate { get; set; }
        public bool AllowObservers { get; set; }
        public string Seed { get; set; }

        public DateTime UploadDate { get; set; }
        public string Link { get; set; }
        public Guid FileHash { get; set; }

        public int DownloadsCounter { get; set; }

        public IList<Player> Players { get; set; }
    }
}
