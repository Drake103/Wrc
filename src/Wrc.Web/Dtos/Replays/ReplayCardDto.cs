using System.Collections.Generic;
using Wrc.Web.Dtos.Replays;

namespace Wrc.Domain.Dtos.Replays
{
    public class ReplayCardDto : ReplayRowDto
    {
        public int ScoreLimit { get; set; }
        public IList<AllianceDto> Alliances { get; set; }
    }
}