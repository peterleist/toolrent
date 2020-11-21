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
    public class CategorysController : ControllerBase
    {
        private ToolRentDbContext _toolRentDbContext;

        public CategorysController(ToolRentDbContext toolRentDbContext)
        {
            _toolRentDbContext = toolRentDbContext;
        }
        // GET: all category
        [HttpGet]
        public IEnumerable<Category> Get()
        {
            return _toolRentDbContext.Categorys;
        }

        // GET: get specific category
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var category = _toolRentDbContext.Categorys.Find(id);

            if (category == null)
            {
                return NotFound();
            }
            return Ok(category);
        }

        // POST add new category
        [HttpPost]
        public void Post([FromBody] Category category)
        {
            _toolRentDbContext.Categorys.Add(category);
            _toolRentDbContext.SaveChanges();
        }

        // PUT cahnge category
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Category category)
        {
            var _category = _toolRentDbContext.Categorys.Find(id);
            category.Name = _category.Name;
            _toolRentDbContext.SaveChanges();
        }

        // DELETE delete category
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var _category = _toolRentDbContext.Categorys.Find(id);

            //Remove connections
            foreach (var con in _toolRentDbContext.CategoryConnection)
            {
                if(con.Id == id)
                {
                    _toolRentDbContext.CategoryConnection.Remove(con);
                }
            }

            _toolRentDbContext.Categorys.Remove(_category);
            _toolRentDbContext.SaveChanges();
        }
    }
}
