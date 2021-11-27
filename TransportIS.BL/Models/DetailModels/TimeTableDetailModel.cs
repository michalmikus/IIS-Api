using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportIS.BL.Models.DetailModels
{
    public class TimeTableDetailModel
    {
        public Guid Id { get; set; }

        public string? StopName { get; set; }

        public Guid StopId { get; set; }

        public Guid ConnectionId { get; set; }

        public string? ConnectionName { get; set; }

        public DateTime TimeOfDeparture { get; set; }
    }
}
