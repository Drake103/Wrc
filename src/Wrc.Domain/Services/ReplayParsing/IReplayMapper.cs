using Wrc.Domain.Dtos.ReplayParsing;
using Wrc.Domain.Models.Replays;

namespace Wrc.Domain.Services.ReplayParsing
{
    public interface IReplayMapper
    {
        Replay GetEntity(ReplayParsedDto replayParsedDto);
    }
}