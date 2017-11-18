using Wrc.Web.Domain;
using Wrc.Web.Domain.Replays;

namespace Wrc.Web.Dal.Replays
{
    public interface IReplayRepositoryFactory
    {
        IReplayRepository Create(IUnitOfWork unitOfWork);
    }
}