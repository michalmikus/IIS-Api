using TransportIS.DAL.Enums;

namespace TransportIS.BL.Models.DetailModels
{
    public class VehicleDetailModel
    {
        public string? Brand { get; set; }

        public string? Model { get; set; }

        public VehicleType Type { get; set; }

        public int? NumberOfSeats { get; set; }

        public string? Description { get; set; }

        public Guid CarrierId { get; set; }
    }
}
