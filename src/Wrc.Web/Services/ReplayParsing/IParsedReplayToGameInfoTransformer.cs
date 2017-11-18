using Wrc.Web.Domain.Replays;
using Wrc.Web.Dtos.ReplayParsing;

namespace Wrc.Web.Services.ReplayParsing
{
    public interface IParsedReplayToGameInfoTransformer
    {
        IGameInfo ToGameInfo(ReplayParsedDto parsed);
    }
}