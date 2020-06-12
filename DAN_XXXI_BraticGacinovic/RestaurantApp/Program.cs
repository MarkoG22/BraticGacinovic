using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantApp
{
    class Program
    {
        static void Main(string[] args)
        {
            string option = null;

            do
            {
                Console.WriteLine("\nWelcome to our restaurant");
                Console.WriteLine("1. Create the order");
                Console.WriteLine("2. Read the order");
                Console.WriteLine("3. Update the order");
                Console.WriteLine("4. Delete the order");
                Console.WriteLine("5. Exit");
                Console.Write("Please choose an option: ");
                option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        break;
                    case "2":
                        break;
                    case "3":
                        break;
                    case "4":
                        break;
                    case "5":
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("\nWrong input, please choose an option in range 1-5.");
                        break;
                }
            } while (!option.Equals("5"));


            Console.ReadLine();
        }
    }
}
