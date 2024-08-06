using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Models.Entities;
using WebApplication1.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MatKulController : ControllerBase
    {

        /*private readonly ApplicationDbContext dbContext;

        public MatKulController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        // GET: api/<MatKulController>
        [HttpGet]
        public IActionResult Get()
        {
            var Matkuls = this.dbContext.Matkuls.ToList();
            return Ok(Matkuls);
        }

        // GET api/<MatKulController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var Matkul = this.dbContext.Matkuls.Find(id);
            return Ok(Matkul);
        }

        // POST api/<MatKulController>
        [HttpPost]
        public void Post(AddMatKulDto MatKulDto)
        {
            var Matkul = new MatKul()
            {
                Nama = MatKulDto.Nama,
                Pengajar = MatKulDto.Pengajar,
                Sks = MatKulDto.Sks
            };
        }

        // PUT api/<MatKulController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<MatKulController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }*/
    }
}
