using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToolRentWebApi.Model;

namespace ToolRentWebApi.Data
{
    public class ToolRentDbContext : DbContext
    {
        public ToolRentDbContext(DbContextOptions<ToolRentDbContext> options) : base(options)
        {

        }
        public DbSet<Tool> Tools { get; set; }


    }
}
