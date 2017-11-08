using Wrc.Domain.Models.Replays;

namespace Wrc.Domain.Dal.Repositories
{
    public interface IPlayerUserRepository : IGenericRepository<PlayerUser>
    {
        PlayerUser GetPlayerUserByEugenUserId(int eugenUserId);
    }
}