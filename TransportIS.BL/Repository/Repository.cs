using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TransportIS.DAL.Entities.Interfaces;
using TransportIS.BL.Repository.Interfaces;
using TransportIS.DAL;

namespace TransportIS.BL.Repository
{
    public class Repository<TEntity> : IRepository<TEntity>
    where TEntity : class, IEntity
    {
        protected TransportISDbContext DbContext { get; }

        protected DbSet<TEntity> dbSet;


        public Repository(Func<TransportISDbContext> contextProvider)
        {
            DbContext = contextProvider();
            dbSet = DbContext.Set<TEntity>();
        }

        public IQueryable<TEntity> GetQueryable()
        {
            return dbSet;
        }

        
        public virtual TEntity? GetEntityById(Guid id)
        {
            return dbSet.FirstOrDefault(entity => entity.Id == id);
        }

        
        public virtual TEntity Insert(TEntity entity)
        {
            entity.Id = dbSet.Add(entity).Entity.Id;
            DbContext.SaveChanges();
            return entity;
        }

        public virtual TEntity Update(TEntity entity)
        {
            entity.Id = dbSet.Update(entity).Entity.Id; 
            return entity;
        }
        

        public void Delete(Guid id)
        {
            var entity = GetEntityById(id);
            if (entity != null)
            {
                dbSet.Remove(entity);
                DbContext.SaveChanges();
            }
        }

        public void SaveChanges()
        {
            DbContext.SaveChanges();
        }

        public IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return GetQueryable().Where(predicate);
        }
    }
}
