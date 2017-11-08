namespace Wrc.Domain.Dtos
{
    public interface IDto : IDto<int>
    {

    }

    public interface IDto<TId> where TId : struct
    {
        TId Id { get; set; }
    }
}
