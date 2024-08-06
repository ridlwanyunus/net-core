namespace WebApplication1.Models.Entities
{
    public class MatKul
    {
        public int Id { get; set; }
        public string Nama { get; set; }

        public int Sks { get; set; }

        public IEnumerable<Mahasiswa> Peserta { get; set; }

        public Dosen Pengajar { get; set; }
    }
}
