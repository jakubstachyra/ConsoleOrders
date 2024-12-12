using System;
using LogicLibrary.Models.Products;

namespace ConsoleOrderApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var orderManager = new OrderManager();
            bool isRunning = true;

            while (isRunning)
            {
                Console.Clear();
                DisplayCart(orderManager);
                Console.WriteLine("Welcome to the Order Management System!");
                Console.WriteLine("Available Products:");
                Console.WriteLine("Laptop - 2500 PLN");
                Console.WriteLine("Keyboard - 120 PLN");
                Console.WriteLine("Mouse - 90 PLN");
                Console.WriteLine("Monitor - 1000 PLN");
                Console.WriteLine("Debugging Duck - 66 PLN\n");

                Console.WriteLine("Please choose an option:");
                Console.WriteLine("1. Add a product");
                Console.WriteLine("2. Remove a product");
                Console.WriteLine("3. Show order value and discounts");
                Console.WriteLine("4. Exit");
                Console.Write("Your choice: ");

                if (!int.TryParse(Console.ReadLine(), out int choice) || choice < 1 || choice > 4)
                {
                    Console.WriteLine("Invalid input. Please select a number between 1 and 4.");
                    Console.ReadKey();
                    continue;
                }

                try
                {
                    switch (choice)
                    {
                        case 1:
                            AddProduct(orderManager);
                            break;
                        case 2:
                            RemoveProduct(orderManager);
                            break;
                        case 3:
                            orderManager.DisplayOrderSummary();
                            break;
                        case 4:
                            isRunning = false;
                            Console.WriteLine("Goodbye!");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                    Console.ReadKey();
                }
            }
        }

        private static void AddProduct(OrderManager orderManager)
        {
            Console.Clear();
            Console.WriteLine("Select a product to add:");
            Console.WriteLine("1. Laptop - 2500 PLN\n2. Keyboard - 120 PLN\n3. Mouse - 90 PLN" +
                "\n4. Monitor - 1000 PLN\n5. Debugging Duck - 66 PLN\n");
            Console.Write("Your choice: ");

            if (!int.TryParse(Console.ReadLine(), out int productChoice) || productChoice < 1 || productChoice > 5)
            {
                Console.WriteLine("Invalid input. Please select a valid product.");
                Console.ReadLine();
                return;
            }

            Console.WriteLine("Enter quantity: ");
            if (!int.TryParse(Console.ReadLine(), out int quantity) || quantity <= 0)
            {
                Console.WriteLine("Invalid input. Quantity must be a positive number.");
                Console.ReadKey();
                return;
            }

            try
            {
                orderManager.AddProduct(productChoice, quantity);
                Console.WriteLine("Product added successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                Console.ReadKey();
            }
        }

        private static void RemoveProduct(OrderManager orderManager)
        {
            Console.Clear();
            Console.WriteLine("Select a product to remove:");
            Console.WriteLine("1. Laptop\n2. Keyboard\n3. Mouse\n4. Monitor\n5. Debugging Duck");
            Console.Write("Your choice: ");

            if (!int.TryParse(Console.ReadLine(), out int productChoice) || productChoice < 1 || productChoice > 5)
            {
                Console.WriteLine("Invalid input. Please select a valid product.");
                Console.ReadKey();
                return;
            }

            try
            {
                orderManager.RemoveProduct(productChoice);
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                Console.ReadKey();
            }
        }

        private static void DisplayCart(OrderManager orderManager)
        {
            Console.WriteLine("Current Cart:");
            var items = orderManager.GetCartItems();

            if (items.Count == 0)
            {
                Console.WriteLine("Your cart is empty.");
            }
            else
            {
                foreach (var item in items)
                {
                    Console.WriteLine(item);
                }
            }

            Console.WriteLine();
        }
    }
}
