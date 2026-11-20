using System.Diagnostics;

namespace Rocket_game

{

    internal class Program
    {
        static string ures = " ° ";
        static string raketa = "[-]";
        static string[] rocket = new string[30];
        static bool vege = false;
        static void Feltoltes()
        {

            for (int i = 0; i < rocket.Length; i++)
            {
                rocket[i] = ures;
            }
            rocket[14] = raketa;
            foreach (var item in rocket)
            {
                Console.Write(item, 5);
            }
        }
        static void mozgas()
        {

            do
            {
                Console.CursorVisible = false;
                char bemenet = Console.ReadKey(true).KeyChar;
                switch (bemenet)
                {
                    case 'a':
                        {
                            for (int i = 0; i < rocket.Length; i++)
                            {
                                if (rocket[i] == raketa)
                                {
                                    if (i != 0)
                                    {
                                        rocket[i] = ures;
                                        rocket[i - 1] = raketa;
                                    }
                                }
                            }
                            break;
                        }
                    case 'A':
                        {
                            for (int i = 0; i < rocket.Length; i++)
                            {
                                if (rocket[i] == raketa)
                                {
                                    if (i != 0)
                                    {
                                        rocket[i] = ures;
                                        rocket[i - 1] = raketa;
                                    }
                                }
                            }
                            break;
                        }
                    case 'd':
                        {
                            for (int i = 0; i < rocket.Length - 1; i++)
                            {
                                if (rocket[i] == raketa)
                                {
                                    if (i != rocket.Length - 1)
                                    {
                                        rocket[i] = ures;
                                        rocket[i + 1] = raketa;
                                        i = rocket.Length-1;
                                    }
                                }
                            }
                            break;
                        }
                    case 'D':
                        {
                            for (int i = 0; i < rocket.Length - 1; i++)
                            {
                                if (rocket[i] == raketa)
                                {
                                    if (i != rocket.Length - 1)
                                    {
                                        rocket[i] = ures;
                                        rocket[i + 1] = raketa;
                                        i = rocket.Length-1;
                                    }
                                }
                            }
                            break;
                        }

                }
                Console.SetCursorPosition(0,0);
                foreach (var item in rocket)
                {
                    Console.Write(item, 5);
                }
            } while (!vege);
        }
        static void Main(string[] args)
        {
            Feltoltes();
            mozgas();
            Jatek();

        static void Jatek()

        {
            Stopwatch ora = Stopwatch.StartNew();
            long utolsoGyorsEsemeny = 0;
            long utolsoLassuEsemeny = 0;

            const int gyorsKozMs = 200;
            const int lassuKozMs = 300;

            int pontszam = 0;
            bool jatekVege = false;

            while (pontszam < 10000 || jatekVege == true)
            {
                long most = ora.ElapsedMilliseconds;
                if (most - utolsoGyorsEsemeny >= gyorsKozMs)
                {
                    // Console.Write(".");
                    utolsoGyorsEsemeny = most;
                }
                if (most - utolsoLassuEsemeny >= lassuKozMs)
                {
                    // Console.Write(" [1 mp] ");
                    utolsoLassuEsemeny = most;
                }
            }
        }
    }
}
