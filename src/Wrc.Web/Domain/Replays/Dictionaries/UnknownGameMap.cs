namespace Wrc.Web.Domain.Replays.Dictionaries
{
    public class UnknownGameMap : IGameMap
    {
        public UnknownGameMap(string publicCode)
        {
            PublicCode = publicCode;
        }

        public string PublicCode { get; }

        public string Name => "Unknown Map";
    }
}