using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToolRentWebApi.Data;
using ToolRentWebApi.Model;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ToolRentWebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ToolsController : ControllerBase
    {
        private ToolRentDbContext _toolRentDbContext;

        public ToolsController(ToolRentDbContext toolRentDbContext)
        {
            _toolRentDbContext = toolRentDbContext;
        }

        //GET: all tool
        [HttpGet]
        public IEnumerable<Tool> GetAllToolWithReservation()
        {
            return _toolRentDbContext.Tools;
        }

        [HttpGet("[action]")]
        public IActionResult GetWithCategory()
        {

            var tools = from c in _toolRentDbContext.CategoryConnection
                        join t in _toolRentDbContext.Tools on c.toolId equals t.Id
                        join cat in _toolRentDbContext.Categorys on c.categoryId equals cat.Id
                        select new { ToolName = t.Name , ToolCategory = cat.Name};

            return Ok(tools);
        }

        // GET: Specific tool
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var tool = _toolRentDbContext.Tools.Find(id);

            if (tool == null) {
                return NotFound();
            }
            return Ok(tool);
        }

        // GET: Get tool categorys
        [HttpGet("[action]/{id}")]
        public IActionResult GetCategory(int id)
        {
            var categorys = from c in _toolRentDbContext.CategoryConnection
                            join category in _toolRentDbContext.Categorys on c.categoryId equals category.Id
                            select category.Name;

            return Ok(categorys);
        }

        [HttpGet("[action]/{id}")]
        public IActionResult GetReservation(int id)
        {
            var reservations = from r in _toolRentDbContext.ReservationConnection
                            where r.toolId == id
                            join res in _toolRentDbContext.Reservations on r.reservationId equals res.Id
                            select res;

            return Ok(reservations);
        }

        // POST: Add category to tool
        [HttpPost("[action]/{id}")]
        public void AddCategory(int id, [FromBody] int categoryId)
        {
            var connection = new CategoryConnection
            {
                toolId = id,
                categoryId = categoryId
            };
            _toolRentDbContext.CategoryConnection.Add(connection);
            _toolRentDbContext.SaveChanges();

        }

        // POST: Add reservation to tool
        [HttpPost("[action]/{id}")]
        public void AddReservation(int id, [FromBody] Reservation reservation)
        {
            _toolRentDbContext.Reservations.Add(reservation);
            _toolRentDbContext.SaveChanges();

            var connection = new ReservationConnection
            {
                toolId = id,
                reservationId = reservation.Id
            };

            _toolRentDbContext.ReservationConnection.Add(connection);
            _toolRentDbContext.SaveChanges();

        }

        // POST: Add tool
        [HttpPost]
        public void Post([FromBody] Tool tool)
        {
            _toolRentDbContext.Tools.Add(tool);
            _toolRentDbContext.SaveChanges();
        }




        // PUT 
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Tool tool)
        {
            var entity = _toolRentDbContext.Tools.Find(id);
            entity.Name = tool.Name;
            entity.Desc = tool.Desc;
            _toolRentDbContext.SaveChanges();
        }

        // DELETE 
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var tool = _toolRentDbContext.Tools.Find(id);
            _toolRentDbContext.Tools.Remove(tool);
            _toolRentDbContext.SaveChanges();
        }
    }
}