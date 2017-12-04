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

        public override string AllianceName => "REDFOR";

        public override int AllianceId => RedforId;

        public static bool IsRedfor(PlayerInfo playerInfo)
        {
            return playerInfo.Alliance == RedforId;
        }

        public static RedforModel CreateFrom(IEnumerable<PlayerInfo> playerInfos)
        {
            var playerModels = playerInfos
                .Where(p => p.Alliance == RedforId)
                .Select(PlayerModel.CreateFrom);
            return new RedforModel(playerModels);
        }
    }
}