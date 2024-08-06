using Microsoft.EntityFrameworkCore;
using WebApplication1.Models.Entities;

namespace WebApplication1.Services
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Dosen> Dosens {  get; set; }

        public DbSet<MatKul> Matkuls { get; set; }

        public DbSet<Mahasiswa> Mahasiswas { get; set; }
    }
}
