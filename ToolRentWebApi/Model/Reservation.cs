using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToolRentWebApi.Model
{
    public class Reservation
    {
        public int Id { get; set; }

        public string Email { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }
    }
}
