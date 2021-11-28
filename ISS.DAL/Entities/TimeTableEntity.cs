using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportIS.DAL.Entities.Interfaces;

namespace TransportIS.DAL.Entities
{
    public class TimeTableEntity : BaseEntity
    {
        [ForeignKey(nameof(StopId))]
        public StopEntity? Stop { get; set; }

        public Guid? StopId { get; set; }

        public Guid? ConnectionId { get; set; }
      
        public DateTime TimeOfDeparture { get; set; }
    }
}
