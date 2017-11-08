using System.Collections.Generic;

namespace Wrc.Domain.Dtos.Replays
{
    public class ReplayCardDto : ReplayDto
    {
        public int ScoreLimit { get; set; }
        public IList<AllianceDto> Alliances { get; set; }
    }
}