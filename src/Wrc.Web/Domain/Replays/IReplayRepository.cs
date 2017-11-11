using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Wrc.Domain.Dtos;
using Wrc.Domain.Dtos.Replays;
using Wrc.Web.Dtos;
using Wrc.Web.Dtos.Replays;

namespace Wrc.Web.Domain.Replays
{
    public interface IReplayRepository
    {
        Task<IReadOnlyList<ReplayRowDto>> ListAsync(PagingInfo pagingInfo, string searchText);
        IReadOnlyList<ReplayRowDto> GetByPlayerUser(int playerUserId, PagingInfo pagingInfo);
        ReplayCardDto GetReplayCard(int replayId);
        int GetTotalCount(string searchText);
        bool IsAlreadyUploaded(Guid fileHash, out string title);

        void Add(Replay replay);
    }
}