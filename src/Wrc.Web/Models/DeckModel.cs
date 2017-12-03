namespace Wrc.Web.Models
{
    public class DeckModel
    {
        public DeckModel(
            string name,
            string content,
            string nationName,
            string nationCode,
            string specializationName,
            string specializationCode)
        {
            Name = name;
            Content = content;
            NationName = nationName;
            NationCode = nationCode;
            SpecializationName = specializationName;
            SpecializationCode = specializationCode;
        }

        public string Name { get; }
        public string Content { get; }
        public string NationName { get; }
        public string NationCode { get; }
        public string SpecializationName { get; }
        public string SpecializationCode { get; }
    }
}