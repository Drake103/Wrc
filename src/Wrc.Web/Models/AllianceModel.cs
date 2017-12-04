using System.Collections.Generic;
using System.Linq;
using Wrc.Web.Domain.Replays;

namespace Wrc.Web.Models
{
    public abstract class AllianceModel
    {
        protected AllianceModel(IEnumerable<PlayerModel> players)
        {
            Players = players.ToArray();
        }

        public abstract string AllianceName { get; }

        public abstract int AllianceId { get; }

        public IReadOnlyList<PlayerModel> Players { get; }
    }
}