using System.Collections.Generic;
using System.Linq;

namespace Wrc.Web.Models
{
    public class AllianceModel
    {
        public AllianceModel(int allianceId, IEnumerable<PlayerModel> players)
        {
            AllianceId = allianceId;
            AllianceName = GetAllianceName(allianceId);
            Players = players.ToArray();
        }

        public string AllianceName { get; }

        public int AllianceId { get; }

        public IReadOnlyList<PlayerModel> Players { get; }

        private string GetAllianceName(int alliance)
        {
            switch (alliance)
            {
                case 0:
                    return "BLUEFOR";
                case 1:
                    return "REDFOR";
                default:
                    return "UNKNOWN";
            }
        }
    }
}