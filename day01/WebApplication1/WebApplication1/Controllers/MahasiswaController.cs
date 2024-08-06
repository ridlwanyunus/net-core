using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Models.Entities;
using WebApplication1.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MahasiswaController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;

        public MahasiswaController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var Mahasiswas = dbContext.Mahasiswas.ToList();
            return Ok(Mahasiswas);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var Mahasiswa = dbContext.Mahasiswas.Find(id);
            return Ok(Mahasiswa);
        }

        [HttpPost]
        public void Post(AddMahasiswaDto addMahasiswaDto)
        {
            var Mahasiswa = new Mahasiswa()
            {
                Nama = addMahasiswaDto.Nama,
                NPM = addMahasiswaDto.NPM,
                Email = addMahasiswaDto.Email
            };
            dbContext.Mahasiswas.Add(Mahasiswa);
            dbContext.SaveChanges();

        }

        [HttpPut("{id}")]
        public void Put(int id, AddMahasiswaDto addMahasiswaDto)
        {
            var Mahasiswa = dbContext.Mahasiswas.Find(id);

            if (Mahasiswa != null)
            {
                Mahasiswa.Nama = addMahasiswaDto.Nama;
                Mahasiswa.NPM = addMahasiswaDto.NPM;
                Mahasiswa.Email = addMahasiswaDto.Email;    
            }

            dbContext.SaveChanges();
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var Mahasiswa = dbContext.Mahasiswas.Find(id);
            dbContext.Mahasiswas.Remove(Mahasiswa);
            dbContext.SaveChanges();
        }
    }
}
