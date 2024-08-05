namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            PegawaiPajak pegawaiA = new PegawaiPajak();
            pegawaiA.DoShout();
            string ktpA = pegawaiA.SayKtp();
            string npwpA = pegawaiA.SayNpwp();
            Console.WriteLine(ktpA);
            Console.WriteLine(npwpA);

            PegawaiSetjen pegawaiB = new PegawaiSetjen();
            pegawaiB.DoShout();
        }
    }
}
