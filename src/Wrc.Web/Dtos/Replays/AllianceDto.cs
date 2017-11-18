using System.Collections.Generic;
using System.Linq;

namespace Wrc.Domain.Dtos.Replays
{
    public class AllianceDto
    {
        public AllianceDto()
        {
            Players = new List<PlayerDto>();
        }

        public AllianceDto(IEnumerable<PlayerDto> players)
        {
            Players = players.ToList();
        }

        public IList<PlayerDto> Players { get; set; }
    }
}