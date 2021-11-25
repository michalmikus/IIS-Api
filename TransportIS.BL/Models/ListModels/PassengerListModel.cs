namespace TransportIS.BL.Models.DetailModels
{
    public class PassengerListModel
    {
        public Guid Id { get; set; }

        public string? CardNumber { get; set; }

        public string? ExpirationDate { get; set; }

        public string? SecurityCode { get; set; }

        public AddressListModel Address { get; set; } = new AddressListModel(); 

        public ICollection<TicketListModel>? Tickets { get; set; } = new List<TicketListModel>();
    }
}
