using TransportIS.DAL.Enums;

namespace TransportIS.BL.Models.DetailModels
{
    public class EmploeeDetailModel
    {
        public Guid Id { get; set; }

        public string? Role { get; set; }

        public string? Email { get; set; }
         
        public string? FullName { get; set; }

        public Guid CarrierId { get; set; }

        public Guid UserId { get; set; }

        public AddressDetailModel Address { get; set; } = new AddressDetailModel();
    }
}
