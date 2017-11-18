using System;
using System.Threading;
using System.Threading.Tasks;
using Wrc.Web.Domain.Replays;

namespace Wrc.Web.Domain
{
    public interface IUnitOfWork : IDisposable
    {
        IReplayRepository ReplayRepository { get; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken));
    }
}