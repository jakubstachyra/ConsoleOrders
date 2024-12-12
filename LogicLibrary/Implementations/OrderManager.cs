using System;
using LogicLibrary.Implementations;
using LogicLibrary.Models.Products;

namespace ConsoleOrderApp
{
    public class OrderManager
    {
        private readonly Order _order;
        private readonly DiscountCalculator _discountCalculator;

        public OrderManager()
        {
            _order = new Order();
            _discountCalculator = new DiscountCalculator();
        }

        public void AddProduct(int productChoice, int quantity)
        {
            Product? selectedProduct = productChoice switch
            {
                1 => new Laptop(),
                2 => new Keyboard(),
                3 => new Mouse(),
                4 => new LogicLibrary.Models.Products.Monitor(),
                5 => new DebuggingDuck(),
                _ => null
            };

            if (selectedProduct == null)
            {
                throw new ArgumentException("Invalid product choice.");
            }

            _order.AddProduct(selectedProduct, quantity);
        }

        public void RemoveProduct(int productChoice)
        {
            Product? selectedProduct = productChoice switch
            {
                1 => new Laptop(),
                2 => new Keyboard(),
                3 => new Mouse(),
                4 => new LogicLibrary.Models.Products.Monitor(),
                5 => new DebuggingDuck(),
                _ => null
            };

            if (selectedProduct == null)
            {
                throw new ArgumentException("Invalid product choice.");
            }

            var existingItem = _order.items.Find(item => item.Product.Name == selectedProduct.Name && item.Product.Price == selectedProduct.Price);
            if (existingItem == null)
            {
                Console.WriteLine($"The product '{selectedProduct.Name}' is not in the order.");
                return;
            }

            _order.RemoveProduct(existingItem.Product);
            Console.WriteLine($"Removed {selectedProduct.Name} from the order.");
        }

        public void DisplayOrderSummary()
        {
            decimal orderValue = _order.GetOrderValue();
            decimal discount = _discountCalculator.CalculateDiscount(_order);
            decimal totalValue = orderValue - discount;

            Console.WriteLine("Current order:");
            foreach (var item in _order.items)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine($"Order Value: {orderValue} PLN");
            Console.WriteLine($"Discount: {discount} PLN");
            Console.WriteLine($"Total after discount: {totalValue} PLN\n");
        }
        public List<string> GetCartItems()
        {
            var cartItems = new List<string>();
            foreach (var item in _order.items)
            {
                cartItems.Add(item.ToString());
            }
            return cartItems;
        }
    }

}
