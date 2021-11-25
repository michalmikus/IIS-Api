using TransportIS.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportIS.DAL.Entities.Interfaces;

namespace TransportIS.DAL
{
    public class CarrierEntity : BaseEntity
    {
        public AddressEntity? Address { get; set; }

        public string? CarrierName { get; set; }

        public string? TaxNumber { get; set; }

        public string? TelephoneNumber { get; set; }

        public string? PublicRelationsContact { get; set; }

        public ICollection<ConnectionEntity> Connections { get; set; } = new List<ConnectionEntity>();

        public ICollection<EmploeeEntity> Emploees { get; set; } = new List<EmploeeEntity>();

        public ICollection<VehicleEntity> Vehicles { get; set; } = new List<VehicleEntity>();

    }
}
