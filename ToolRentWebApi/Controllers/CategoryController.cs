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
    public class CategoryController : ControllerBase
    {
        private ToolRentDbContext _toolRentDbContext;

        public CategoryController(ToolRentDbContext toolRentDbContext)
        {
            _toolRentDbContext = toolRentDbContext;
        }
        // GET: api/<CategoryController>
        [HttpGet]
        public IEnumerable<Category> Get()
        {
            return _toolRentDbContext.Categorys;
        }

        // GET api/<CategoryController>/5
        [HttpGet("{id}")]
        public Category Get(int id)
        {
            return _toolRentDbContext.Categorys.Find(id);
        }

        // POST api/<CategoryController>
        [HttpPost]
        public void Post([FromBody] Category category)
        {
            _toolRentDbContext.Categorys.Add(category);
            _toolRentDbContext.SaveChanges();
        }

        // PUT api/<CategoryController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CategoryController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
