using System;
using Wrc.Web.Domain.Replays;

namespace Wrc.Web.Models
{
    public class PlayerModel
    {
        private PlayerModel(int id, string name, int level, int rank, int elo, DeckModel deck)
        {
            Id = id;
            Name = name;
            Level = level;
            Rank = rank;
            Elo = elo;
            Deck = deck;
        }

        public int Id { get; }
        public string Name { get; }
        public int Level { get; }
        public int Rank { get; }
        public int Elo { get; }
        public DeckModel Deck { get; }

        public static PlayerModel CreateFrom(PlayerInfo playerInfo)
        {
            return new PlayerModel(
                playerInfo.Id,
                playerInfo.Name,
                playerInfo.Level,
                playerInfo.Rank,
                (int) Math.Round(playerInfo.Elo),
                DeckContentHelper.GetDeckInfo(playerInfo.DeckName, playerInfo.DeckContent));
        }
    }
}