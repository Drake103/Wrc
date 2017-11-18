namespace Wrc.Web.Domain.Replays.Dictionaries
{
    public class GameType : IGameType
    {
        public GameType(string publicCode, string name)
        {
            PublicCode = publicCode;
            Name = name;
        }

        public string PublicCode { get; }
        public string Name { get; }
    }
}