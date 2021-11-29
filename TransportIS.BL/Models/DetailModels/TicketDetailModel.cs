using TransportIS.DAL.Enums;

namespace TransportIS.BL.Models.DetailModels
{
    public class TicketDetailModel
    {
        public string? Type { get; set; }

        public string? Price { get; set; }

        public Guid PassengerId { get; set; }

        public string? BoardingStopName { get; set; }
        public Guid BoardingStopId { get; set; }

        public string? DestinationStopName { get; set; }
        public Guid DestinationStopId { get; set; }

    }
}
