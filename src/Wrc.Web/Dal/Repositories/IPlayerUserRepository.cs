using Wrc.Web.Domain.Replays;

namespace Wrc.Web.Dal.Repositories
{
    public interface IPlayerUserRepository
    {
        PlayerUser GetPlayerUserByEugenUserId(int eugenUserId);
    }
}