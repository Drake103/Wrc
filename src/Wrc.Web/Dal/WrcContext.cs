using System;
using Microsoft.EntityFrameworkCore;
using Wrc.Web.Dal.Replays;
using Wrc.Web.Domain;
using Wrc.Web.Domain.Replays;

namespace Wrc.Web.Dal
{
    public class WrcContext : DbContext, IUnitOfWork
    {
        private readonly Lazy<IReplayRepository> _lazyReplayRepository;

        public WrcContext()
        {
            _lazyReplayRepository = new Lazy<IReplayRepository>(() => new ReplayRepository(this));
        }


        public IReplayRepository ReplayRepository => _lazyReplayRepository.Value;
        
        public DbSet<Replay> Replays { get; }
    }
}