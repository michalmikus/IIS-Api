using TransportIS.DAL.Entities;
using TransportIS.DAL.Enums;

namespace TransportIS.DAL
{
    public class VehicleEntity : BaseEntity
    {
        public string? Brand { get; set; }

        public string? Model { get; set; }

        public VehicleType Type { get; set; }

        public string? VehicleRegistrationNumber { get; set; }

        public int? NumberOfSeats { get; set; }

        public string? Description { get; set; }

        public Guid CarrierId { get; set; }
    }
}