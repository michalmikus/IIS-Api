namespace TransportIS.BL.Models.DetailModels
{
    public class PassengerDetailModel
    {
        public Guid Id { get; set; }

        public string? CardNumber { get; set; }

        public string? ExpirationDate { get; set; }

        public string? SecurityCode { get; set; }

        public AddressDetailModel Address { get; set; } = new AddressDetailModel(); 

        public ICollection<TicketDetailModel>? Tickets { get; set; } = new List<TicketDetailModel>();
    }
}
