namespace Wrc.Web.Domain
{
    public interface IEntity : IEntity<int>
    {

    }

    public interface IEntity<TId> where TId : struct
    {
        TId Id { get; set; }
    }
}
