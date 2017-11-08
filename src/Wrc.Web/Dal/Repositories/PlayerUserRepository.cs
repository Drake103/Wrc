using System.Linq;
using Wrc.Domain.Models.Replays;

namespace Wrc.Domain.Dal.Repositories
{
    public class PlayerUserRepository : GenericRepository<PlayerUser>, IPlayerUserRepository
    {
        public PlayerUserRepository(ICrudRepository<PlayerUser> crud) : base(crud)
        {
        }

        public PlayerUser GetPlayerUserByEugenUserId(int eugenUserId)
        {
            return _crud.Get().SingleOrDefault(x => x.EugenUserId == eugenUserId);
        }
    }
}