using Microsoft.Extensions.Configuration;
using Wrc.Web.Dal.Replays;
using Wrc.Web.Domain;

namespace Wrc.Web.Dal
{
    public class WrcContextFactory : IUnitOfWorkFactory
    {
        private readonly IConfiguration _configuration;
        private readonly IReplayRepositoryFactory _replayRepositoryFactory;

        public WrcContextFactory(
            IConfiguration configuration,
            IReplayRepositoryFactory replayRepositoryFactory)
        {
            _configuration = configuration;
            _replayRepositoryFactory = replayRepositoryFactory;
        }

        public IUnitOfWork Create()
        {
            return new WrcContext(_configuration, _replayRepositoryFactory);
        }
    }
}