using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportIS.DAL.Entities.Interfaces;

namespace TransportIS.DAL.Entities
{
    public class PassengerEntity : BaseEntity
    {
        public string? PhoneNumber { get; set; }

        public string? Email { get; set; }

        public AddressEntity? Address { get; set; }

        public Guid UserId { get; set; }

        public Guid ConnectionId { get; set; }

        public Guid TicketId { get; set; }

    }
}
