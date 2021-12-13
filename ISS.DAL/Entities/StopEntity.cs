using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportIS.DAL.Entities.Interfaces;

namespace TransportIS.DAL.Entities
{
    public class StopEntity : BaseEntity
    {
        public string? Name     { get; set; }
        public string? Location { get; set; }

        [ForeignKey(nameof(CarrierId))]
        public CarrierEntity? Carrier { get; set; }
        public Guid? CarrierId { get; set; }

        public EmploeeEntity? ResponsibleEmploee { get; set; }

        public ICollection<TimeTableEntity> Connections { get; set; } = new List<TimeTableEntity>();
    }
}
