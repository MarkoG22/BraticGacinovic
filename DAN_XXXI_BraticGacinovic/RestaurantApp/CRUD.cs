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
<<<<<<< HEAD
        /// method for creating the order
        /// </summary>
        public void Create()
        {
            // dictionary for displaying the restaurant Menu
=======
        /// method for updating orders, deleting the order and creating new with the same code and ID
        /// </summary>
        public void Update()
        {
            // inputs and validations
            Console.Write("Please enter your order code: ");
            bool isValid = int.TryParse(Console.ReadLine(), out int code);

            while (isValid == false)
            {
                Console.WriteLine("Wrong input, please try again.");
                isValid = int.TryParse(Console.ReadLine(), out code);
            }

            // calling method for displaying the restaurant Menu
>>>>>>> Feature/MarkoGacinovic
            Dictionary<int, string> RestaurantMenu = ShowMenu();

            try
            {
                using (RestaurantBraticGacinovicEntities context = new RestaurantBraticGacinovicEntities())
                {
                    tblRecord record = new tblRecord();
<<<<<<< HEAD
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
=======

                    // finding order to edit
                    tblRecord recordToEdit = (from x in context.tblRecords where x.Code == code select x).First();
                    List<tblOrder> list = (from y in context.tblOrders where y.RecordID == recordToEdit.RecordID select y).ToList();

                    // deleting the order
                    context.tblOrders.RemoveRange(list);
                    if (recordToEdit != null)
                    {
                        string exit = null;

                        // loop for creating new order at the same code and ID
                        do
                        {
                            Console.WriteLine("Input ID of the article: ");
                            bool inputID = int.TryParse(Console.ReadLine(), out int id);

                            while (inputID == false)
                            {
                                Console.WriteLine("Wrong input, please try again.");
                                inputID = int.TryParse(Console.ReadLine(), out id);
                            }

                            Console.WriteLine("Input quantity: ");
                            bool inputQuantity = int.TryParse(Console.ReadLine(), out int quantity);

                            while (inputID == false)
                            {
                                Console.WriteLine("Wrong input, please try again.");
                                inputQuantity = int.TryParse(Console.ReadLine(), out quantity);
                            }

                            // creating new order
                            if (RestaurantMenu.ContainsKey(id))
                            {
                                tblOrder order = new tblOrder();
                                order.Article = RestaurantMenu[id];
                                order.Quantity = quantity;
                                order.RecordID = recordToEdit.RecordID;
                                context.tblOrders.Add(order);
                            }
                            Console.WriteLine("\nIf you want to finish order press 'x', or press 'enter' to continue.");
                            exit = Console.ReadLine();

                        } while (exit != "x");

                        context.SaveChanges();
                    }
                    else
                    {
                        Console.WriteLine("\nYour order does not exist, please try again.");
                    }
>>>>>>> Feature/MarkoGacinovic
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Error");
            }
        }

        /// <summary>
<<<<<<< HEAD
        /// method for reading the order
        /// </summary>
        public void Read()
        {
            // input and validation
            Console.WriteLine("Input code of record you want to view");
=======
        /// method for deleting the order
        /// </summary>
        public void Delete()
        {
            // inputs and validations
            Console.WriteLine("Input code of record you want to delete");
>>>>>>> Feature/MarkoGacinovic
            bool isValid = int.TryParse(Console.ReadLine(), out int code);

            while (isValid == false)
            {
                Console.WriteLine("Wrong input, please try again.");
                isValid = int.TryParse(Console.ReadLine(), out code);
            }

<<<<<<< HEAD

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
=======
            try
            {
                // finding the order and deleting it from the database
                using (RestaurantBraticGacinovicEntities context = new RestaurantBraticGacinovicEntities())
                {
                    tblRecord recordToDelete = (from x in context.tblRecords where x.Code == code select x).First();
                    List<tblOrder> list = (from x in context.tblOrders where x.RecordID == recordToDelete.RecordID select x).ToList();
                    context.tblOrders.RemoveRange(list);
                    context.tblRecords.Remove(recordToDelete);
                    context.SaveChanges();
>>>>>>> Feature/MarkoGacinovic
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
<<<<<<< HEAD
            // dictionary for articles with IDs and article names
=======
            // dictionary for articles with ID as keys and article names as values
>>>>>>> Feature/MarkoGacinovic
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
