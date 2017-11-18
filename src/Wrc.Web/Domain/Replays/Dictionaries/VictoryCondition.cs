namespace Wrc.Web.Domain.Replays.Dictionaries
{
    public class VictoryCondition : IVictoryCondition
    {
        public VictoryCondition(string publicCode, string name)
        {
            PublicCode = publicCode;
            Name = name;
        }

        public string PublicCode { get; }
        public string Name { get; }
    }
}