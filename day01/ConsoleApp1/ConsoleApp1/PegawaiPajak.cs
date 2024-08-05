using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{

    internal class PegawaiPajak : Pegawai, IPersonal
    {
        public override void DoShout()
        {
            Console.WriteLine("Saya seorang pegawai pajak.");
            Console.WriteLine($"Hari kerja saya {HariKerja.SENIN},{HariKerja.SELASA},{HariKerja.RABU}");
        }

        public string SayKtp()
        {
            return "KTP Saya 123";
        }

        public string SayNpwp()
        {
            return "NPWP Saya 456";
        }
    }
}
