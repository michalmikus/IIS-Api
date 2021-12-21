using TransportIS.DAL.Enums;

namespace TransportIS.BL.Models.DetailModels
{
    public class TicketListModel
    {
        public Guid Id { get; set; }

        public string? Price { get; set; }

        public string? BoardingStopName { get; set; }

        public string? DestinationStopName { get; set; }

        public Guid? ConfirmingEmploeeId { get; set; }

        public string? Type { get; set; }
    }
}
