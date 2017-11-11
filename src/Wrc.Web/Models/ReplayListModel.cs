using System.Collections.Generic;
using Wrc.Web.Dtos.Replays;

namespace Wrc.Web.Models
{
    public class ReplayListModel
    {
        public ReplayListModel(IReadOnlyList<ReplayRowDto> replays)
        {
            Replays = replays;
        }

        public IReadOnlyList<ReplayRowDto> Replays { get; }
    }
}