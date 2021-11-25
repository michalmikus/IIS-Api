using System.ComponentModel.DataAnnotations.Schema;

namespace TransportIS.DAL.Entities
{
    public class EmploeeConnectionAssigment:BaseEntity
    {
        [ForeignKey(nameof(EmploeeId))]
        public EmploeeEntity? Emploee { get; set; }
        public Guid? EmploeeId { get; set; }


        [ForeignKey(nameof(ConnectionId))]
        public CarrierEntity? Connection { get; set; }
        public Guid? ConnectionId { get; set; }
    }    
}
