using System.Collections.Generic;
using System.IO;
using Wrc.Domain.Dtos;
using Wrc.Domain.Dtos.Replays;
using Wrc.Domain.Models.Replays;

namespace Wrc.Domain.Services
{
    public interface IReplayService
    {
        Replay SaveReplay(Stream replayFile, string filePath);
        bool IsAlreadyUploaded(Stream replayFile, out string title);
        ReplayCardDto GetReplayCard(int replayId);
        IList<ReplayDto> GetReplays(PagingInfo pagingInfo, string searchText);
        IList<ReplayDto> GetReplaysByPlayerUser(int playerUserId, PagingInfo pagingInfo);
        int GetReplaysCount(string searchText);
    }
}