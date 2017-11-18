using System.Collections.Generic;
using System.Threading.Tasks;
using Wrc.Web.Dtos;

namespace Wrc.Web.Domain.Replays
{
    public interface IReplayRepository
    {
        Task<IReadOnlyList<LightReplay>> ListAsync(PagingInfo pagingInfo, string searchText);
        Task<IReadOnlyList<LightReplay>> GetByAccountAsync(int accountId, PagingInfo pagingInfo);
        Task<Replay> GetReplayAsync(int replayId);
        Task<int> GetTotalCountAsync(string searchText);
        Task<Replay> GetByFileHashAsync(string fileHash);

        void Add(Replay replayRecord);
    }
}