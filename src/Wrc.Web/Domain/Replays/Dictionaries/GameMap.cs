namespace Wrc.Web.Domain.Replays.Dictionaries
{
    public class GameMap : IGameMap
    {
        public GameMap(string publicCode, string name)
        {
            PublicCode = publicCode;
            Name = name;
        }

        public string PublicCode { get; }

        public string Name { get; }
    }
}