using Wrc.Web.Domain;

namespace Wrc.Web.Dal
{
    public class WrcContextFactory : IUnitOfWorkFactory
    {
        public IUnitOfWork Create()
        {
            return new WrcContext();
        }
    }
}