namespace Wrc.Web.Domain.Replays.Dictionaries
{
    public class UnknownVictoryCondition : IVictoryCondition
    {
        public UnknownVictoryCondition(string publicCode)
        {
            PublicCode = publicCode;
        }

        public string PublicCode { get; }

        public string Name => "Unknown Victory Condition";
    }
}