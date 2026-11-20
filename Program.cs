namespace Rocket_game
{
    internal class Program
    {
        static string[,] matrix = new string[15,30];
        static Random r= new Random();



        static void Feltolt()
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = "<->";
                    
                }
            }
            ;
            for (int i = 0; i < 1; i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    int legyen = r.Next(1,3);
                    if (legyen == 1)
                    {
                        Console.Write($"    ");
                    }
                        else
                    {
                        Console.Write($"{matrix[i, j],3} ");
                    }
                    

                }
                Console.WriteLine();
            }
























        }
        
        static void Main(string[] args)
        {
                Feltolt();
        }
    }
}
