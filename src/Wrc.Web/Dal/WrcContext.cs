using System;
using Microsoft.EntityFrameworkCore;
using Wrc.Web.Dal.Replays;
using Wrc.Web.Domain;
using Wrc.Web.Domain.Replays;
using Microsoft.Extensions.Configuration;

namespace Wrc.Web.Dal
{
    public class WrcContext : DbContext, IUnitOfWork
    {
        private readonly Lazy<IReplayRepository> _lazyReplayRepository;
        readonly IConfiguration configuration;

        public WrcContext(IConfiguration configuration)
        {
            this.configuration = configuration;
            _lazyReplayRepository = new Lazy<IReplayRepository>(() => new ReplayRepository(this));
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(configuration["ConnectionStrings:Main"]);
        }

        public IReplayRepository ReplayRepository => _lazyReplayRepository.Value;
        
        public DbSet<Replay> Replays { get; set; }
    }
}