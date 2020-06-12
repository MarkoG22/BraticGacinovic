using RestaurantApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantApp
{
    public partial class CRUD
    {
        /// <summary>
        /// method for creating the order
        /// </summary>
        public void Create()
        {
            // dictionary for displaying the restaurant Menu
            Dictionary<int, string> RestaurantMenu = ShowMenu();

            try
            {
                using (RestaurantBraticGacinovicEntities context = new RestaurantBraticGacinovicEntities())
                {
                    tblRecord record = new tblRecord();
                    Random rnd = new Random();

                    // variables for creating record in table Records and taking random order code
                    record.OrderTime = DateTime.Now;
                    record.Code = rnd.Next(1, 9999);
                    context.tblRecords.Add(record);

                    string exit = null;

                    // loop for creating the order
                    do
                    {
                        // inputs and validations
                        Console.WriteLine("Input ID of the article: ");
                        bool isValid = int.TryParse(Console.ReadLine(), out int id);

                        while (isValid==false)
                        {
                            Console.WriteLine("Wrong input, please try again.");
                            isValid = int.TryParse(Console.ReadLine(), out id);
                        }

                        // loop for checking if the article exists in the Menu
                        if (!RestaurantMenu.ContainsKey(id))
                        {
                            Console.WriteLine("The article does not exist.");
                            return;
                        }

                        Console.WriteLine("Input quantity: ");
                        bool inputQuantity = int.TryParse(Console.ReadLine(), out int quantity);

                        while (inputQuantity == false)
                        {
                            Console.WriteLine("Wrong input, please try again.");
                            inputQuantity = int.TryParse(Console.ReadLine(), out quantity);
                        }

                        // loop for checking if article exists and creating the order
                        if (RestaurantMenu.ContainsKey(id))
                        {
                            tblOrder order = new tblOrder();
                            order.Article = RestaurantMenu[id];
                            order.Quantity = quantity;
                            order.RecordID = record.RecordID;
                            context.tblOrders.Add(order);
                        }
                       

                        Console.WriteLine("If you want to finish order press 'x', or press 'enter' to continue.");
                        exit = Console.ReadLine();

                    } while (exit != "x");

                    Console.WriteLine("\nCode of your order: " + record.Code);


                    context.SaveChanges();
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Error");
            }
        }

        /// <summary>
        /// method for reading the order
        /// </summary>
        public void Read()
        {
            // input and validation
            Console.WriteLine("Input code of record you want to view");
            bool isValid = int.TryParse(Console.ReadLine(), out int code);

            while (isValid == false)
            {
                Console.WriteLine("Wrong input, please try again.");
                isValid = int.TryParse(Console.ReadLine(), out code);
            }


            try
            {
                using (RestaurantBraticGacinovicEntities context = new RestaurantBraticGacinovicEntities())
                {
                    // finding the order in the database with ID
                    tblRecord recordToView = (from x in context.tblRecords where x.Code == code select x).First();
                    List<tblOrder> list = (from x in context.tblOrders where x.RecordID == recordToView.RecordID select x).ToList();

                    // displaying the order
                    foreach (var item in list)
                    {
                        Console.WriteLine(item.Article + " " + item.Quantity);
                    }
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Error");
            }
        }

        /// <summary>
        /// method for displaying the restaurant Menu
        /// </summary>
        /// <returns></returns>
        private static Dictionary<int, string> ShowMenu()
        {
            // dictionary for articles with IDs and article names
            Dictionary<int, string> RestaurantMenu = new Dictionary<int, string>();

            RestaurantMenu[0] = "Burger";
            RestaurantMenu[1] = "Chicken sandwich";
            RestaurantMenu[2] = "Pizza";
            RestaurantMenu[3] = "Chicken pasta";
            RestaurantMenu[4] = "Bolognese";
            RestaurantMenu[5] = "Carbonare";
            RestaurantMenu[6] = "Chicken soup";
            RestaurantMenu[7] = "Coca cola";
            RestaurantMenu[8] = "Lemonade";
            RestaurantMenu[9] = "Mineral water";
            RestaurantMenu[10] = "Pepsi";
            RestaurantMenu[11] = "Still water";

            // displaying the dictionary
            foreach (var item in RestaurantMenu)
            {
                Console.WriteLine(item.Key + " " + item.Value);
            }

            return RestaurantMenu;
        }
    }
}
