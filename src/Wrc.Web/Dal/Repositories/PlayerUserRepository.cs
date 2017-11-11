using System;
using Wrc.Web.Domain.Replays;

namespace Wrc.Web.Dal.Repositories
{
    public class PlayerUserRepository : IPlayerUserRepository
    {
        public PlayerUser GetPlayerUserByEugenUserId(int eugenUserId)
        {
            throw new NotImplementedException();
            /*return _crud.Get().SingleOrDefault(x => x.EugenUserId == eugenUserId);*/
        }
    }
}