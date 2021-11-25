using System;
using System.Collections.Generic;
using System.Text;
using TransportIS.BL.Factories.Interfaces;
using TransportIS.DAL.Entities.Interfaces;

namespace TransportIS.BL.Factories
{
    public class DefaultEntityFactory : IEntityFactory
    {
        public DefaultEntityFactory()
        {
        }
        
        public TEntity Create<TEntity>(Guid id) where TEntity : class, IEntity, new() => new();
    }
}