using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToolRentWebApi.Model
{
    public class ReservationConnection
    {
        public int id { get; set; }

        public int toolId { get; set; }
        
        public int reservationId { get; set; }
    }
}
