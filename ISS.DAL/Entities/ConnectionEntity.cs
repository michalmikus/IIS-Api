using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportIS.DAL.Entities.Interfaces;
using TransportIS.DAL.Enums;

namespace TransportIS.DAL.Entities
{
    public class ConnectionEntity : BaseEntity
    {
        public string? Name { get; set; }

        public string? Description { get; set; } 

        public int? ReservedSeats { get; set; }


        [ForeignKey(nameof(VehicleId))]
        public VehicleEntity? Vehicle { get; set; }
        public Guid? VehicleId { get; set; }


        [ForeignKey(nameof(CarrierId))]
        public CarrierEntity? Carrier { get; set; }
        public Guid? CarrierId { get; set; }


        public ICollection<EmploeeConnectionAssigment> Emploees { get; set; } = new List<EmploeeConnectionAssigment>();

        public ICollection<StopEntity> Stops { get; set; } = new List<StopEntity>();

        public ICollection<TicketEntity> Tickets { get; set; } = new List<TicketEntity>();
    }
}
