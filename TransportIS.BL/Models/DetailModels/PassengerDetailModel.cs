namespace TransportIS.BL.Models.DetailModels
{
    public class PassengerDetailModel
    {
        public AddressDetailModel Address { get; set; } = new AddressDetailModel();

        public Guid Id { get; set; }

        public string? Email { get; set; }

        public string? PhoneNumber { get; set; }

        public Guid TicketId { get; set; }
    }
}
