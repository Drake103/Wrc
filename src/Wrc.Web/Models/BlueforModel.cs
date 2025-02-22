﻿using System.Collections.Generic;
using System.Linq;
using Wrc.Web.Domain.Replays;

namespace Wrc.Web.Models
{
    public class BlueforModel : AllianceModel
    {
        private const int BlueforId = 0;

        private BlueforModel(IEnumerable<PlayerModel> players) : base(players)
        {
        }

        public override int Id => BlueforId;

        public override string Name => "BLUEFOR";

        public static BlueforModel CreateFrom(IEnumerable<PlayerInfo> playerInfos)
        {
            var playerModels = playerInfos
                .Where(p => p.Alliance == BlueforId)
                .Select(PlayerModel.CreateFrom);
            return new BlueforModel(playerModels);
        }
    }
}