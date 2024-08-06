using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models.Entities;
using WebApplication1.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MahasiswaJsonController : ControllerBase
    {

        private readonly MahasiswaJsonService _service;

        public MahasiswaJsonController(MahasiswaJsonService service)
        {
            this._service = service;
        }

        // GET: api/<MahasiswaJsonController>
        [HttpGet]
        public IEnumerable<Mahasiswa> Get()
        {
            return _service.GetAll();
        }

        // GET api/<MahasiswaJsonController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<MahasiswaJsonController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<MahasiswaJsonController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<MahasiswaJsonController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
