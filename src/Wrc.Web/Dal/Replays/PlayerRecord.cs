namespace Wrc.Web.Dal.Replays
{
    public class PlayerRecord
    {
        public int Id { get; set; }
        public double Elo { get; set; }
        public int Rank { get; set; }
        public int Level { get; set; }
        public string Name { get; set; }
        public string TeamName { get; set; }
        public string Avatar { get; set; }
        public string IALevel { get; set; }
        public bool WasReady { get; set; }
        public string DeckName { get; set; }
        public string DeckContent { get; set; }
        public int Alliance { get; set; }
        public bool IsEnteredInLobby { get; set; }
        public int ScoreLimit { get; set; }
        public int IncomeRate { get; set; }
        public int Number { get; set; }

        public AccountRecord AccountRecord { get; set; }

        public ReplayRecord ReplayRecord { get; set; }
    }
}