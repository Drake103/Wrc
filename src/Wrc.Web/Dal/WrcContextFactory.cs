using Microsoft.Extensions.Configuration;
using Wrc.Web.Domain;

namespace Wrc.Web.Dal
{
    public class WrcContextFactory : IUnitOfWorkFactory
    {
        readonly IConfiguration configuration;

        public WrcContextFactory(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public IUnitOfWork Create()
        {
            return new WrcContext(configuration);
        }
    }
}