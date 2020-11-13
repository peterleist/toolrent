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
    public class ToolsController : ControllerBase
    {
        private ToolRentDbContext _toolRentDbContext;

        public ToolsController(ToolRentDbContext toolRentDbContext)
        {
            _toolRentDbContext = toolRentDbContext;
        }

        // GET: api/<ToolsController>
        [HttpGet]
        public IEnumerable<Tool> Get()
        {
            return _toolRentDbContext.Tools;
        }

        // GET api/<ToolsController>/5
        [HttpGet("{id}")]
        public Tool Get(int id)
        {
            return _toolRentDbContext.Tools.Find(id);
        }

        // POST api/<ToolsController>
        [HttpPost]
        public void Post([FromBody] Tool tool)
        {
            _toolRentDbContext.Tools.Add(tool);
            _toolRentDbContext.SaveChanges();
        }

        // PUT api/<ToolsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Tool tool)
        {
            var entity = _toolRentDbContext.Tools.Find(id);
            entity.Name = tool.Name;
            entity.Desc = tool.Desc;
            _toolRentDbContext.SaveChanges();
        }

        // DELETE api/<ToolsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var entity = _toolRentDbContext.Tools.Find(id);
            _toolRentDbContext.Tools.Remove(entity);
            _toolRentDbContext.SaveChanges();
        }
    }
}
