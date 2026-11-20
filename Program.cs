namespace Rocket_game
{
    internal class Program
    {
        static string[,] matrix = new string[15, 30];
        static Random r = new Random();
        static string ufo = "<->";
        static string ures = "   ";
        static int sor = 1;


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

        static void Main(string[] args)
        {
            Feltolt();
            Kiir();
            Console.CursorVisible = false;
            Console.ReadLine();
            Console.Clear();
            Modosit();
            Kiir();
    
            Console.ReadLine();
            Console.Clear();
            Modosit();
            Kiir();
        }
    }
}
