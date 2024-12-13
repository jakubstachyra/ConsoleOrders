using System;
using ConsoleOrders;
using LogicLibrary.Implementations;
using LogicLibrary.Models.Products;

namespace ConsoleOrderApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var orderManager = new OrderManager();
            var consoleUI = new ConsoleUI(orderManager);

            consoleUI.Run();
        }
    }
}
