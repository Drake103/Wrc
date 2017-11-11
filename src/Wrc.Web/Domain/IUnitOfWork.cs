using System;
using System.Threading;
using System.Threading.Tasks;
using Wrc.Web.Domain.Replays;

namespace Wrc.Web.Domain
{
    public interface IUnitOfWork : IDisposable
    {
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken));
        
        IReplayRepository ReplayRepository { get; }
    }
}