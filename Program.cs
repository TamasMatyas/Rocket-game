namespace Rocket_game
{
    internal class Program
    {
        static string ures = " ° ";
        static string raketa = "[-]";
        static string[] rocket = new string[30];
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
            char bemenet = Console.ReadLine()[0];

        }
        static void Main(string[] args)
        {
            Feltoltes();
            mozgas();
        }


    }
}
