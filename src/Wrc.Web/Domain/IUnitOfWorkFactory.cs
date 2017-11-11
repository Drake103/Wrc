namespace Wrc.Web.Domain
{
    public interface IUnitOfWorkFactory
    {
        IUnitOfWork Create();
    }
}