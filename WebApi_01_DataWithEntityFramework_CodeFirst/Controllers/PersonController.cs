using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi_01_DataWithEntityFramework_CodeFirst.Data;
using WebApi_01_DataWithEntityFramework_CodeFirst.Models;

namespace WebApi_01_DataWithEntityFramework_CodeFirst.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        PersonDbContext _ctx;

        public PersonController(PersonDbContext context)
        {
            _ctx = context;
        }

        [HttpGet]
        public IActionResult Person(int id = 1)
        {
            if (_ctx == null)
                return NotFound();

            Person? p = _ctx.People.FirstOrDefault(x => x.Id == id);
            
            if (p == null)
                return NotFound();

            return Ok(p);
        }
    }
}
