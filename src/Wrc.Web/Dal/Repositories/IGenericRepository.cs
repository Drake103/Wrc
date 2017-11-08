using System.Collections.Generic;
using Wrc.Domain.Dtos;
using Wrc.Domain.Models;

namespace Wrc.Domain.Dal.Repositories
{
    public interface IGenericRepository<TEntity> where TEntity : IEntity
    {
        IList<TEntity> Get(PagingInfo pagingInfo = PagingInfo.All);
        TEntity GetById(int id);
        void Save(TEntity entity);
        void Delete(TEntity entity);
        int GetTotalCount();
    }
}