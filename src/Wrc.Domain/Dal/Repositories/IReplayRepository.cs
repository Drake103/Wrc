using System;
using System.Collections.Generic;
using Wrc.Domain.Dtos;
using Wrc.Domain.Dtos.Replays;
using Wrc.Domain.Models.Replays;

namespace Wrc.Domain.Dal.Repositories
{
    public interface IReplayRepository : IGenericRepository<Replay>
    {
        IList<ReplayDto> GetForList(PagingInfo pagingInfo, string searchText);
        IList<ReplayDto> GetByPlayerUser(int playerUserId, PagingInfo pagingInfo);
        ReplayCardDto GetReplayCard(int replayId);
        int GetTotalCount(string searchText);
        bool IsAlreadyUploaded(Guid fileHash, out string title);
    }
}