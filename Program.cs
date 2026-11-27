using System.Diagnostics;

namespace Rocket_game

{

    internal class Program
    {
        static string[,] matrix = new string[15, 30];
        static Random r = new Random();
        static string ufo = "<->";
        static string ures = "   ";
        static string uresHajo = " ° ";
        static string raketa = "[-]";
        static string lovedek = " ^ ";
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
            UFoSorPlus();
        }
        static void UFoSorPlus()
        {
            for (int i = 0; i < matrix.GetLength(1); i++)
            {
                int leszer = r.Next(0, 2);
                if (leszer == 0)
                {
                    matrix[0, i] = ufo;
                }
                else
                {
                    matrix[0, i] = ures;
                }
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
                    Console.Write($"{matrix[i, j]}");
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
                Console.Write(item, 3);
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
                case ' ':
                    {
                        Loves();
                        break;
                    }

            }
        }
        static void Loves()
        {
            for (int i = 0; i < rocket.Length; i++)
            {
                if (rocket[i] == raketa)
                {
                    matrix[matrix.GetLength(0) - 2, i] = lovedek;
                }
            }
        }
        static void LovedekMozgat()
        {
            for (int i = 1; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] == lovedek)
                    {
                        if (matrix[i - 1, j] == ufo)
                        {
                            matrix[i - 1, j] = ures;
                            matrix[i, j] = ures;
                            pontszam += 100;
                        }
                        else if (i == 1)
                        {
                            matrix[i, j] = ures;
                        }
                        else
                        {
                            matrix[i - 1, j] = lovedek;
                            matrix[i, j] = ures;
                        }
                    }
                }
            }
        }




        static bool Lent()
        {
            bool vege = false;
            for (int i = 0; i < matrix.GetLength(1); i++)
            {
                if (matrix[matrix.GetLength(0) - 1, i] == ufo)
                {
                    vege = true;
                }
            }
            
            return vege;
        }
        static void Main(string[] args)
        {
            long utolsoGyorsEsemeny = 0;
            long utolsoLassuEsemeny = 0;
            long vegejatekvaras = 0;
            long vegeido = 0;
            

            const int gyorsKozMs = 100;
            const int lassuKozMs = 1800;
            const int varas = 3000;
            Feltolt();
            FeltoltHajo();
            Console.CursorVisible = false;
            while (pontszam < 10000 && jatekVege != true)
            {
                if (Console.KeyAvailable)
                {
                    Hajo();

                }
                
                Kiir();
                HajoKiir();
                Console.SetCursorPosition(0, 0);
                long most = ora.ElapsedMilliseconds;
                if (most - utolsoGyorsEsemeny >= gyorsKozMs)
                {
                    LovedekMozgat();
                    utolsoGyorsEsemeny = most;
                }
                if (most - utolsoLassuEsemeny >= lassuKozMs)
                {
                    Modosit();
                    UFoSorPlus();
                    utolsoLassuEsemeny = most;
                }
                if (Lent() || most - utolsoLassuEsemeny >= lassuKozMs )
                {
                    jatekVege = true;
                    Console.Clear();
                    Console.WriteLine("Game Over!");
                    Console.WriteLine($"Pontszám: {pontszam}");
                    
                }
                if (pontszam >= 1000)
                {
                    jatekVege = true;
                    Console.Clear();
                    Console.WriteLine("Gratulálunk nyerték");
                    Console.WriteLine($"Pontszám: {pontszam}");
                    int vegeszo;
                    do
                    {
                        vegeszo = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("A játék véget ért, nyomj 0-t a kilépéshez.");
                    } while (vegeszo != 0);
                        
                
            }
        }


    }
}
 