using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToolRentWebApi.Model
{
    public class CategoryConnection
    {
        public int Id { get; set; }

        public int toolId { get; set; }

        public int categoryId { get; set; }
    }
}
