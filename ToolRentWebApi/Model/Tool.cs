﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToolRentWebApi.Model
{
    public class Tool
    {

        public int Id { get; set; }
        public string Name { get; set; }

        public string Desc { get; set; }

        public string Category { get; set; }

        public ICollection<Reservation> Reservations { get; set; }
    }
}
