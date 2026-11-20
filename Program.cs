using System.Diagnostics;

namespace Rocket_game

{

    internal class Program
    {

        static void Jatek()

        {
            Stopwatch ora = Stopwatch.StartNew();
            long utolsoGyorsEsemeny = 0;
            long utolsoLassuEsemeny = 0;
            const int gyorsKozMs = 100;
            const int lassuKozMs = 300;
            int pontszam = 0;
            while (pontszam < 10000)
            {
                long most = ora.ElapsedMilliseconds;
                if (most - utolsoGyorsEsemeny >= gyorsKozMs)
                {
                    Console.Write(".");
                    utolsoGyorsEsemeny = most;
                }
                if (most - utolsoLassuEsemeny >= lassuKozMs)
                {
                    Console.Write(" [1 mp] ");
                    utolsoLassuEsemeny = most;
                }
            }
        }
        static void Main(string[] args)
        {
            Jatek();
        }
    }
}
