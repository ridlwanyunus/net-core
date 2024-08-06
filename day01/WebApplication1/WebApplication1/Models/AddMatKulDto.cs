using WebApplication1.Models.Entities;

namespace WebApplication1.Models
{
    public class AddMatKulDto
    {
        public string Nama { get; set; }

        public int Sks { get; set; }

        public Dosen Pengajar { get; set; }
    }
}
