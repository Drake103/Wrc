using System;

namespace Wrc.Domain.Models {
    public class GenericDictionaryItem : IEntity
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual string ResourceName { get; set; }
        public virtual string PublicCode { get; set; }
        public virtual DateTime DateStart { get; set; }
        public virtual DateTime? DateEnd { get; set; }
    }
}
