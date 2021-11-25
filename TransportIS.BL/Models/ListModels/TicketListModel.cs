using TransportIS.DAL.Enums;

namespace TransportIS.BL.Models.DetailModels
{
    public class TicketListModel
    {
        public Guid Id { get; set; }

        public int TravelClass { get; set; }

        public string? Price { get; set; }

        public Guid PassangerId { get; set; }

        public StopListModel BoardingStopId { get; set; } = new StopListModel();

        public StopListModel DestinationStopId { get; set; } = new StopListModel();

        public PassengerType Type { get; set; }
    }
}
