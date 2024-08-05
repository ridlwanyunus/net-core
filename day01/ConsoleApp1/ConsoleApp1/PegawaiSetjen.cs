using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class PegawaiSetjen : Pegawai
    {
        public override void DoShout()
        {
            Console.WriteLine("Saya seorang pegawai setjen.");
        }
    }
}
