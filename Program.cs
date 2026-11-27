using System.Diagnostics;

namespace Rocket_game

{

    internal class Program
    {
        static string[,] matrix = new string[15, 30];
        static Random r = new Random();
        static string ufo = "<->";
        static string ures = "   ";
        static int sor = 1;
        static string uresHajo = " ° ";
        static string raketa = "[-]";
        static string[] rocket = new string[30];
        static bool jatekVege = false;
        static int pontszam = 0;
        static Stopwatch ora = Stopwatch.StartNew();

        static void Feltolt()
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = ures;

                }
            }
            for (int i = 0; i < matrix.GetLength(1) / 2; i++)
            {
                int index = r.Next(1, matrix.GetLength(0) - 1);
                matrix[0, index] = ufo;
            }
        }
        static void FeltoltHajo()
        {
            for (int i = 0; i < rocket.Length; i++)
            {
                rocket[i] = uresHajo;
            }
            rocket[14] = raketa;
        }
        static void Kiir()
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write($"{matrix[i, j],3}");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
        static void Modosit()
        {
            for (int i = matrix.GetLength(0) - 2; i >= 0; i--)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] == ufo)
                    {
                        matrix[i + 1, j] = ufo;
                        matrix[i, j] = ures;
                    }
                }
            }

        }
        static void HajoKiir()
        {
            foreach (var item in rocket)
            {
                Console.Write(item, 5);
            }
            Console.WriteLine();
        }
        static void Hajo()
        {
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
                                    rocket[i] = uresHajo;
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
                                    rocket[i] = uresHajo;
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
                                    rocket[i] = uresHajo;
                                    rocket[i + 1] = raketa;
                                    i = rocket.Length - 1;
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
                                    rocket[i] = uresHajo;
                                    rocket[i + 1] = raketa;
                                    i = rocket.Length - 1;
                                }
                            }
                        }
                        break;
                    }

            }
        }


        static void Main(string[] args)
        {
            long utolsoGyorsEsemeny = 0;
            long utolsoLassuEsemeny = 0;

            const int gyorsKozMs = 200;
            const int lassuKozMs = 300;
            Feltolt();
            FeltoltHajo();
            Console.CursorVisible = false;
            while (pontszam < 10000 || jatekVege == true)
            {
                if (Console.KeyAvailable)
                {
                    Hajo();
                }
                Kiir();
                HajoKiir();
                Console.SetCursorPosition(0, 0);
                //Console.Clear();
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


            Modosit();
            Kiir();
            Console.ReadLine();
            Console.Clear();
            Modosit();
            Kiir();


        }
    }
}
