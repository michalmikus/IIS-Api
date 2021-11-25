using TransportIS.DAL.Enums;

namespace TransportIS.BL.Models.DetailModels
{
    public class EmploeeDetailModel
    {
        public Guid Id { get; set; }

        public EmploeeRole? Role { get; set; }

        public Guid ConnectionId { get; set; }

        public Guid CarrierId   { get; set; }

        public AddressDetailModel Address { get; set; } = new AddressDetailModel();
    }
}
