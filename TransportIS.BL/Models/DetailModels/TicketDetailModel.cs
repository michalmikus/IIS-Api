using TransportIS.DAL.Enums;

namespace TransportIS.BL.Models.DetailModels
{
    public class TicketDetailModel
    {
        public string? Type { get; set; }

        public string? Price { get; set; }

        public Guid PassengerId { get; set; }

        public Guid? ConfirmingEmploeeId { get; set; }

        public Guid CarrierId { get; set; }
        public string? BoardingStopName { get; set; }
        public Guid BoardingStopId { get; set; }

        public int SeatCount { get; set; }

        public string? DestinationStopName { get; set; }
        public Guid DestinationStopId { get; set; }

    }
}
