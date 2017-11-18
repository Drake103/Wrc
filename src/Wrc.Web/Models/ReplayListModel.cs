using System.Collections.Generic;
using System.Linq;
using Wrc.Web.Domain.Replays;

namespace Wrc.Web.Models
{
    public class ReplayListModel
    {
        public ReplayListModel(IReadOnlyList<LightReplay> replays)
        {
            Replays = replays.Select(r => new ReplayRowModel(r)).ToList();
        }

        public IReadOnlyList<ReplayRowModel> Replays { get; }
    }
}