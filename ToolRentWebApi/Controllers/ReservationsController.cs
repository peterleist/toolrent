using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToolRentWebApi.Data;
using ToolRentWebApi.Model;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ToolRentWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationsController : ControllerBase
    {

        private ToolRentDbContext _toolRentDbContext;

        public ReservationsController(ToolRentDbContext toolRentDbContext)
        {
            _toolRentDbContext = toolRentDbContext;
        }

        // GET: api/<ReserveationsController>
        [HttpGet]
        public IEnumerable<Reservation> Get()
        {
            return _toolRentDbContext.Reservations;
        }

        // DELETE api/<ReserveationsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var reservation = _toolRentDbContext.Reservations.Find(id);
            _toolRentDbContext.Remove(reservation);
            _toolRentDbContext.SaveChanges();
        }
    }
}
