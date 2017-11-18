using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Wrc.Web.Dal.Replays;
using Wrc.Web.Domain;
using Wrc.Web.Domain.Replays;

namespace Wrc.Web.Dal
{
    public class WrcContext : DbContext, IUnitOfWork
    {
        private readonly IConfiguration _configuration;
        private readonly Lazy<IReplayRepository> _lazyReplayRepository;

        public WrcContext(
            IConfiguration configuration,
            IReplayRepositoryFactory replayRepositoryFactory)
        {
            _configuration = configuration;

            _lazyReplayRepository = new Lazy<IReplayRepository>(() => replayRepositoryFactory.Create(this));
        }

        public DbSet<ReplayRecord> Replays { get; set; }

        public DbSet<AccountRecord> Accounts { get; set; }

        public IReplayRepository ReplayRepository => _lazyReplayRepository.Value;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            MapReplayRecord(modelBuilder);
            MapPlayerRecord(modelBuilder);
            MapAccountRecord(modelBuilder);
        }

        private void MapAccountRecord(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AccountRecord>().ToTable("account");
            modelBuilder.Entity<AccountRecord>().HasKey(e => e.Id);
        }

        private void MapPlayerRecord(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PlayerRecord>().ToTable("player");
            modelBuilder.Entity<PlayerRecord>().HasKey(e => e.Id);

            modelBuilder.Entity<PlayerRecord>()
                .HasOne(p => p.ReplayRecord)
                .WithMany(p => p.Players);
        }

        private static void MapReplayRecord(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ReplayRecord>().ToTable("replay");
            modelBuilder.Entity<ReplayRecord>().HasKey(e => e.Id);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(_configuration["ConnectionStrings:Main"]);
        }
    }
}