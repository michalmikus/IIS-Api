using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportIS.BL.Models.DetailModels
{
    public class TimeTableListModel
    {
        public Guid Id { get; set; }

        public string? StopName { get; set; }

        public Guid Stopid { get; set; }

        public Guid ConnectionId { get; set; }

        public DateTime TimeOfDeparture { get; set; }
    }
}
