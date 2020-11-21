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

        public DbSet<CategoryConnection> CategoryConnection { get; set; }

        public DbSet<ReservationConnection> ReservationConnection { get; set; }

        public DbSet<Category> Categorys { get; set; }

        public DbSet<Reservation> Reservations { get; set; }


    }
}
