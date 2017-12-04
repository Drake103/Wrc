using System.Collections.Generic;
using System.Linq;
using Wrc.Web.Domain.Replays;

namespace Wrc.Web.Models
{
    public class RedforModel : AllianceModel
    {
        private const int RedforId = 1;

        private RedforModel(IEnumerable<PlayerModel> players) : base(players)
        {
        }

        public override int Id => RedforId;

        public override string Name => "REDFOR";

        public static RedforModel CreateFrom(IEnumerable<PlayerInfo> playerInfos)
        {
            var playerModels = playerInfos
                .Where(p => p.Alliance == RedforId)
                .Select(PlayerModel.CreateFrom);
            return new RedforModel(playerModels);
        }
    }
}