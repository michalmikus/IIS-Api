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


        [ForeignKey(nameof(ConfirmingEmploeeId))]
        public EmploeeEntity? ConfirmingEmploee { get; set; }
        public Guid? ConfirmingEmploeeId { get; set; }


        [ForeignKey(nameof(PassangerId))]
        public  PassengerEntity? Passanger { get; set; }
        public Guid? PassangerId { get; set; }


        [ForeignKey(nameof(BoardingStopId))]
        public StopEntity? BoardingStop  { get; set; }
        public Guid? BoardingStopId { get; set; }


        [ForeignKey(nameof(DestinationStopId))]
        public StopEntity? DestinationStop { get; set; }
        public Guid? DestinationStopId { get; set; }
        
        public PassengerType Type { get; set; }

        public ICollection<SeatEntity> SeatNumbers { get; set; } = new List<SeatEntity>();
    }
}
