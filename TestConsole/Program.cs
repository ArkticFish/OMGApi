using System;

namespace TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {

            string reply;

            do
            {

                Console.WriteLine("OMG Api Test");
                Console.WriteLine("-----------------------------");
                Console.WriteLine("1. Search by title and year.");
                Console.WriteLine("2. Search by IMDB ID.");
                Console.WriteLine("-----------------------------");
                Console.WriteLine("3. Create custom entry.");
                Console.WriteLine("4. Query all cached entries.");
                Console.WriteLine("5. Update cached entry.");
                Console.WriteLine("6. Delete cached entry.");
                Console.WriteLine("-----------------------------");
                reply = Console.ReadLine();

            }
            while (reply != "");





        }
    }
}
