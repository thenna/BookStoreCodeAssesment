using System;
using System.Linq;
using System.Linq.Expressions;

namespace BookStore.Application.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class
    {
        TEntity Get(string id);
        IQueryable<TEntity> GetAll();
        IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
        TEntity Add(TEntity entity);
        void Update(TEntity entity);
        IQueryable<TEntity> AddRange(IQueryable<TEntity> entities);
        void UpdateRange(IQueryable<TEntity> entities);
        void Remove(TEntity entity);
        void RemoveRange(IQueryable<TEntity> entities);
        void Detach(TEntity entity);
        void DetachList(IQueryable<TEntity> entity);
        void ModifyRange(IQueryable<TEntity> entities);
        void Modify(TEntity entity);
	}
}
