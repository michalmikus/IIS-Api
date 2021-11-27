using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportIS.DAL.Entities.Interfaces;
using TransportIS.DAL.Enums;

namespace TransportIS.DAL.Entities
{
    public class EmploeeEntity : BaseEntity
    {
        public EmploeeRole? Role { get; set; }

        public string? Email { get; set; }

        public Guid? CarrierId { get; set; }

        public Guid UserId { get; set; }

        public AddressEntity? Address { get; set; }
    }
}
