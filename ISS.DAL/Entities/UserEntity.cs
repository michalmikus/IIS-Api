using Microsoft.AspNetCore.Identity;

namespace TransportIS.DAL.Entities
{
    public class UserEntity : IdentityUser<Guid>
    {
        public Guid EmployeeId { get; set; }

        public Guid PassangerId { get; set; }
    }
}
