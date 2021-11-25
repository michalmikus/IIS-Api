using Microsoft.EntityFrameworkCore;

namespace TransportIS.DAL.Entities
{
    [Owned]
    public class AddressEntity
    {
        public string? Name { get; set; }

        public string? Surname { get; set; }

        public string? Address { get; set; }

        public string? Country { get; set; }
    }
}
