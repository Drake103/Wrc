using System.IO;
using System.Threading.Tasks;
using Wrc.Domain.Dtos;
using Wrc.Web.Domain.Replays;

namespace Wrc.Web.Services.Replays
{
    public interface IReplayService
    {
        Task<Replay> SaveReplayAsync(Stream replayFile, string filePath);
        bool IsAlreadyUploaded(Stream replayFile, out string title);
    }
}