using System.Linq;
using Wrc.Domain.Models;

namespace Wrc.Domain.Dal.Repositories
{
    public interface ICrudRepository<TEntity> where TEntity : IEntity
    {
        TEntity GetById(int id);
        void Save(TEntity entity);
        void Delete(TEntity entity);
        void Detach(TEntity entity);
        IQueryable<TEntity> Get();
    }
}