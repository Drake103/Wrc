using System.IO;
using Wrc.Domain.Dtos.ReplayParsing;

namespace Wrc.Domain.Services.ReplayParsing
{
    public interface IReplayParser
    {
        ReplayParsedDto ParseFile(Stream replayFile);
    }
}