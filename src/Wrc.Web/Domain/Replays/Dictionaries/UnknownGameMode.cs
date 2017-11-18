namespace Wrc.Web.Domain.Replays.Dictionaries
{
    public class UnknownGameMode : IGameMode
    {
        public UnknownGameMode(string publicCode)
        {
            PublicCode = publicCode;
        }

        public string PublicCode { get; }

        public string Name => "Unknown Mode";
    }
}