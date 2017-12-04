using System.Collections.Generic;
using System.Linq;

namespace Wrc.Web.Models
{
    public abstract class AllianceModel
    {
        protected AllianceModel(IEnumerable<PlayerModel> players)
        {
            Players = players.ToArray();
        }

        public abstract int Id { get; }

        public abstract string Name { get; }

        public IReadOnlyList<PlayerModel> Players { get; }
    }
}