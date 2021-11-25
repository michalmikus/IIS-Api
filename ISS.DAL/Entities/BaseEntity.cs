using TransportIS.DAL.Entities.Interfaces;

namespace TransportIS.DAL.Entities
{
    public class BaseEntity : IEntity
    {
        public Guid Id { get; set; }
    }
}
