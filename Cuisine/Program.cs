using System;

namespace Cuisine
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Console de la cuisine");
                Cuisine cuisine = new Cuisine();
                cuisine.AnnoncerChangement = Console.WriteLine;
                while (true) // Cuisine éternelle
                    cuisine.Tour();
            }
            catch (Exception e)
            {
                Console.Error.WriteLine(e.Message);
            }
            Console.ReadKey();
        }
    }
}
