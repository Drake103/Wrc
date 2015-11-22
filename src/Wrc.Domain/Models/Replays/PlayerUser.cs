namespace Wrc.Domain.Models.Replays
{
    public class PlayerUser : IEntity
    {
        public virtual int Id { get; set; }
        public virtual int EugenUserId { get; set; }
        public virtual string Name { get; set; }
    }
}
