using System;
using System.Collections.Generic;
using Wrc.Domain.Models.Replays.Dictionaries;

namespace Wrc.Domain.Models.Replays
{
    public class Replay : IEntity
    {
        public virtual int Id { get; set; }

        public virtual string Title { get; set; }
        public virtual bool IsNetworkMode { get; set; }
        public virtual string Version { get; set; }
        public virtual GameMode GameMode { get; set; }
        public virtual GameMap GameMap { get; set; }
        public virtual int MaxPlayers { get; set; }
        public virtual bool AI { get; set; }
        public virtual GameType GameType { get; set; }
        public virtual bool Private { get; set; }
        public virtual int InitMoney { get; set; }
        public virtual int ScoreLimit { get; set; }
        public virtual string ServerName { get; set; }
        public virtual VictoryCondition VictoryCondition { get; set; }
        public virtual string NationConstraint { get; set; }
        public virtual string ThematicConstraint { get; set; }
        public virtual string DateConstraint { get; set; }
        public virtual int IncomeRate { get; set; }
        public virtual bool AllowObservers { get; set; }
        public virtual string Seed { get; set; }

        public virtual DateTime UploadDate { get; set; }
        public virtual string Link { get; set; }
        public virtual Guid FileHash { get; set; }

        public virtual int DownloadsCounter { get; set; }

        public virtual IList<Player> Players { get; set; }
    }
}
