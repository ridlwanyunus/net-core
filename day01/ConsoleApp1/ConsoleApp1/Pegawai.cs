using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal abstract class Pegawai
    {
        public string Nip {  get; set; }

        public virtual void DoShout()
        {
            Console.WriteLine("Saya seorang pegawai.");
        }

    }

    public enum HariKerja
    {
        SENIN, SELASA, RABU, KAMIS, JUMAT
    }
}
