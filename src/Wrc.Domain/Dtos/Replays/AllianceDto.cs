using System.Collections.Generic;

namespace Wrc.Domain.Dtos.Replays
{
    public class AllianceDto
    {
        public AllianceDto()
        {
            Players = new List<PlayerDto>();
        }

        public AllianceDto(IList<PlayerDto> players)
        {
            Players = players;
        }

        public IList<PlayerDto> Players { get; set; }
    }
}