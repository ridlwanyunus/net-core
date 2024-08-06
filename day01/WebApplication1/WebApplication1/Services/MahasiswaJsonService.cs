using System.Text.Json.Serialization;
using Newtonsoft.Json;
using WebApplication1.Models.Entities;


namespace WebApplication1.Services
{
    public class MahasiswaJsonService
    {
        public IEnumerable<Mahasiswa> GetAll()
        {
            using (StreamReader r = new StreamReader("Data/Mahasiswa.json"))
            {
                String json = r.ReadToEnd();
                IEnumerable<Mahasiswa> mahasiswas = JsonConvert.DeserializeObject<IEnumerable<Mahasiswa>>(json);
                return mahasiswas;
            }
        }
    }
}
