using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportIS.DAL.Entities.Interfaces;

namespace TransportIS.BL.Repository.Interfaces
{
    public interface IRepository<TEntity>
        where TEntity : IEntity
    {
        public IQueryable<TEntity> GetQueryable();

        
        public TEntity? GetEntityById(Guid id);
        
        public TEntity Insert(TEntity entity);
        
        public TEntity Update(TEntity entity);

        public void SaveChanges();

        public void Delete(Guid id);
    }
}
