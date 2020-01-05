using System;
using System.Linq;
using System.Linq.Expressions;
using BookStore.Application.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Application.Services
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly DbContext Context;

        protected Repository(DbContext context)
        {
            Context = context;
        }

        public TEntity Add(TEntity entity)
        {
            Context.Add(entity);
            return entity;
        }

        public void Update(TEntity entity)
        {
            Context.Entry(entity).State = EntityState.Modified;
            Context.Update(entity);
        }

        public IQueryable<TEntity> AddRange(IQueryable<TEntity> entities)
        {
            Context.AddRange(entities);
            return entities;
        }

        public void UpdateRange(IQueryable<TEntity> entities)
        {
            Context.UpdateRange(entities);
        }

        public IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            //var entity = Context.Set<TEntity>().Where(predicate); //To Avoid tracking error

            //Context.Entry(entity).State = EntityState.Detached;
            //return entity;
            return Context.Set<TEntity>().Where(predicate).AsNoTracking();

        }

        public TEntity Get(string id)
        {
            return Context.Set<TEntity>().Find(id);
        }
        public IQueryable<TEntity> GetAll()
        {
            return Context.Set<TEntity>();
        }

        public void Remove(TEntity entity)
        {
            //Context.Entry(entity).State = EntityState.Deleted;
            Context.Remove(entity);
        }

        public void RemoveRange(IQueryable<TEntity> entities)
        {
            Context.RemoveRange(entities);
        }

        public void Detach(TEntity entity)
        {
            Context.Entry(entity).State = EntityState.Detached;
        }

        public void Modify(TEntity entity)
        {
            Context.Entry(entity).State = EntityState.Modified;
        }

        public void ModifyRange(IQueryable<TEntity> entities)
        {
            Context.Entry(entities).State = EntityState.Modified;
        }

        public void DetachList(IQueryable<TEntity> entity)
        {
            foreach (var t in entity)
            {
                Context.Entry(t).State = EntityState.Detached;
            }

        }


    }
}