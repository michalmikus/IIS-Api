using TransportIS.DAL.Enums;

namespace TransportIS.BL.Models.DetailModels
{
    public class EmploeeListModel
    {
        public Guid Id { get; set; }

        public string? Name { get; set; }

        public string? Role { get; set; }
    }
}
