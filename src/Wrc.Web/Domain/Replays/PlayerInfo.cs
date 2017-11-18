namespace Wrc.Web.Domain.Replays
{
    public class PlayerInfo
    {
        public PlayerInfo(
            int id,
            AccountInfo accountInfo,
            double elo,
            int rank,
            int level,
            string name,
            string teamName,
            string avatar,
            string iaLevel,
            bool wasReady,
            string deckName,
            string deckContent,
            int alliance,
            bool isEnteredInLobby,
            int scoreLimit,
            int incomeRate,
            int number)
        {
            Id = id;
            AccountInfo = accountInfo;
            Elo = elo;
            Rank = rank;
            Level = level;
            Name = name;
            TeamName = teamName;
            Avatar = avatar;
            IALevel = iaLevel;
            WasReady = wasReady;
            DeckName = deckName;
            DeckContent = deckContent;
            Alliance = alliance;
            IsEnteredInLobby = isEnteredInLobby;
            ScoreLimit = scoreLimit;
            IncomeRate = incomeRate;
            Number = number;
        }

        public int Id { get; }
        public AccountInfo AccountInfo { get; }
        public double Elo { get; }
        public int Rank { get; }
        public int Level { get; }
        public string Name { get; }
        public string TeamName { get; }
        public string Avatar { get; }
        public string IALevel { get; }
        public bool WasReady { get; }
        public string DeckName { get; }
        public string DeckContent { get; }
        public int Alliance { get; }
        public bool IsEnteredInLobby { get; }
        public int ScoreLimit { get; }
        public int IncomeRate { get; }

        public int Number { get; }
    }
}