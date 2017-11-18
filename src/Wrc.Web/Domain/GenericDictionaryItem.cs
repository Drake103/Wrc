namespace Wrc.Web.Domain
{
    public class GenericDictionaryItem : IEntity, IPublicCodeProvider
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PublicCode { get; set; }
    }
}