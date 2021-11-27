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
    public class EmploeeEntity : BaseEntity
    {
        public EmploeeRole? Role { get; set; }

        public string? Email { get; set; }


        [ForeignKey(nameof(ConnectionId))]
        public ConnectionEntity? Connection { get; set; }
        public Guid? ConnectionId { get; set; }


        [ForeignKey(nameof(CarrierId))]
        public ConnectionEntity? Carried { get; set; }
        public Guid? CarrierId { get; set; }

        public ICollection<EmploeeConnectionAssigment> Connections { get; set; } = new List<EmploeeConnectionAssigment>();

        public AddressEntity? Address { get; set; }
    }
}
