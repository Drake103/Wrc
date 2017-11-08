using System.Collections.Generic;
using System.Linq;
using Wrc.Domain.Dtos;
using Wrc.Domain.Models;

namespace Wrc.Domain.Dal.Repositories
{
    public class GenericRepository<TEntity>
        : IGenericRepository<TEntity> where TEntity : IEntity
    {
        protected readonly ICrudRepository<TEntity> _crud;

        public GenericRepository(ICrudRepository<TEntity> crud)
        {
            _crud = crud;
        }

        public IList<TEntity> Get(PagingInfo pagingInfo = PagingInfo.All)
        {
            if (pagingInfo == PagingInfo.All)
            {
                return _crud.Get().ToList();
            }

            return _crud.Get().Skip(pagingInfo.StartIndex).Take(pagingInfo.PageSize).ToList();
        }

        public TEntity GetById(int id)
        {
            return _crud.GetById(id);
        }

        public void Save(TEntity entity)
        {
            _crud.Save(entity);
        }

        public void Delete(TEntity entity)
        {
            _crud.Save(entity);
        }

        public int GetTotalCount()
        {
            return _crud.Get().Count();
        }
    }
}