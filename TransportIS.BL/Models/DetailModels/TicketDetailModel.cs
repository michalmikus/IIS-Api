using TransportIS.DAL.Enums;

namespace TransportIS.BL.Models.DetailModels
{
    public class TicketDetailModel
    {
        public Guid Id { get; set; }

        public int TravelClass { get; set; }

        public string? Price { get; set; }

        public StopDetailModel BoardingStopId { get; set; } = new StopDetailModel();

        public StopDetailModel DestinationStopId { get; set; } = new StopDetailModel();

        public PassengerType Type { get; set; }
    }
}
