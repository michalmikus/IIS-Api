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
        public int? TravelClass { get; set; }

        public string? Price { get; set; }

        public Guid? ConfirmingEmploeeId { get; set; }

        public Guid? PassangerId { get; set; }

        public Guid? BoardingStopId { get; set; }

        public Guid? DestinationStopId { get; set; }
        
        public PassengerType Type { get; set; }

        public int SeatCount  { get; set; }
    }
}
