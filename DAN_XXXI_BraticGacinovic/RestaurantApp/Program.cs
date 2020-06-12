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
            // object for calling methods
            CRUD crud = new CRUD();

            string option = null;

<<<<<<< HEAD
            // object for calling methods
            CRUD crud = new CRUD();

            // loop for the Main Menu
=======
            // loop for Main Menu
>>>>>>> Feature/MarkoGacinovic
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
                        crud.Create();
                        break;
                    case "2":
                        crud.Read();
                        break;
                    case "3":
                        crud.Update();
                        break;
                    case "4":
                        crud.Delete();
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
