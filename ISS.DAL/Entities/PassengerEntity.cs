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
        public string? CardNumber { get; set; }

        public string? ExpirationDate { get; set; }

        public string? SecurityCode { get; set; }

        public AddressEntity? Address { get; set; }

    }
}
