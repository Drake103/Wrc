namespace Wrc.Domain.Models
{
    public interface IEntity : IEntity<int>
    {

    }

    public interface IEntity<TId> where TId : struct
    {
        TId Id { get; set; }
    }
}
