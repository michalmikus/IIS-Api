using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportIS.DAL.Enums;

namespace TransportIS.BL.Models.ListModels
{
    public class VehicleListModel
    {
        public Guid Id { get; set; }
        public string? Brand { get; set; }

        public string? Model { get; set; }

        public VehicleType Type { get; set; }

        public int? NumberOfSeats { get; set; }
    }
}

