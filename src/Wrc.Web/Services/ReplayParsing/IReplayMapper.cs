using Wrc.Web.Domain.Replays;
using Wrc.Web.Dtos.ReplayParsing;

namespace Wrc.Web.Services.ReplayParsing
{
    public interface IReplayMapper
    {
        Replay GetEntity(ReplayParsedDto replayParsedDto);
    }
}