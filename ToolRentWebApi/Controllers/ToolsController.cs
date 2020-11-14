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
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ToolsController : ControllerBase
    {
        private ToolRentDbContext _toolRentDbContext;

        public ToolsController(ToolRentDbContext toolRentDbContext)
        {
            _toolRentDbContext = toolRentDbContext;
        }

        // GET: All tools
        [HttpGet]
        public IEnumerable<Tool> Get()
        {
            return _toolRentDbContext.Tools.Include("Reservations");
        }

        // GET: Specific tool
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var tool = _toolRentDbContext.Tools.Include("Reservations").FirstOrDefault(m=>m.Id == id);

            if (tool == null) {
                return NotFound();
            }

            return Ok(tool);
        }

        // POST: Add tool
        [HttpPost]
        public void Post([FromBody] Tool tool)
        {
            _toolRentDbContext.Tools.Add(tool);
            _toolRentDbContext.SaveChanges();
        }

        // SetCategory
        [HttpPut]
        [Route("[action]/{id}")]
        public void SetCategory(int id, [FromBody] int categoryId)
        {
            var entity = _toolRentDbContext.Tools.Find(id);
            entity.Category = _toolRentDbContext.Categorys.Find(categoryId).Name;
            _toolRentDbContext.SaveChanges();
        }


        // Add reservation
        [HttpPost]
        [Route("[action]/{id}")]
        public void AddReservation(int id, [FromBody] Reservation reservation)
        {
            var entity =_toolRentDbContext.Tools.Find(id);
            reservation.ToolId = id;
            _toolRentDbContext.Reservations.Add(reservation);
            _toolRentDbContext.SaveChanges();
        }

        // PUT 
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Tool tool)
        {
            var entity = _toolRentDbContext.Tools.Find(id);
            entity.Name = tool.Name;
            entity.Desc = tool.Desc;
            entity.Category = tool.Category;
            _toolRentDbContext.SaveChanges();
        }

        // DELETE 
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var tool = _toolRentDbContext.Tools.Include("Reservations").FirstOrDefault(m => m.Id == id);
            _toolRentDbContext.Tools.Remove(tool);
            _toolRentDbContext.SaveChanges();
        }
    }
}