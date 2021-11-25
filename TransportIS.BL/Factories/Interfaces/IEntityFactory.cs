using System;
using TransportIS.DAL.Entities.Interfaces;

namespace TransportIS.BL.Factories.Interfaces
{
    public interface IEntityFactory
    {
        TEntity Create<TEntity>(Guid id) where TEntity : class, IEntity, new();
    }
}
