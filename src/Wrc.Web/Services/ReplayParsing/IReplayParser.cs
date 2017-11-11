using System.IO;
using Wrc.Web.Dtos.ReplayParsing;

namespace Wrc.Web.Services.ReplayParsing
{
    public interface IReplayParser
    {
        ReplayParsedDto ParseFile(Stream replayFile);
    }
}