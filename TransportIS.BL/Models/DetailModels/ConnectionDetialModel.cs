using TransportIS.DAL.Enums;

namespace TransportIS.BL.Models.DetailModels
{
    public class ConnectionDetialModel
    {
        public Guid Id { get; set; }

        public string? Name { get; set; }

        public int? ReservedSeats { get; set; }

        public int? EmptySeats { get; set; }

        public Guid? VehicleId { get; set; }

        public Guid? CarrierId { get; set; }

    }
}
