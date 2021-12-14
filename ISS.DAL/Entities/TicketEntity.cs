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
    public class TicketEntity : BaseEntity
    {
        public string? Price { get; set; }

        public Guid? ConfirmingEmploeeId { get; set; }

        public Guid PassengerId { get; set; }

        public Guid CarrierId { get; set; }

        public Guid BoardingStopId { get; set; }

        public string? BoardingStopName { get; set; }

        public Guid DestinationStopId { get; set; }

        public string? DestinationStopName { get; set; }

        public string? Type { get; set; }

        public int SeatCount  { get; set; }
    }
}
