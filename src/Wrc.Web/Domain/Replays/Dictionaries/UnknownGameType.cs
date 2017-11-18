namespace Wrc.Web.Domain.Replays.Dictionaries
{
    public class UnknownGameType : IGameType
    {
        public UnknownGameType(string publicCode)
        {
            PublicCode = publicCode;
        }

        public string PublicCode { get; }

        public string Name => "Unknown Game Type";
    }
}