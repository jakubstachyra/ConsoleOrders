namespace LogicLibrary.Models.Products
{
    public abstract class Product
    {
        public string Name { get; set; }
        public decimal Price { get; set; }

        protected Product(string name, decimal price)
        {
            Name = name;
            Price = price;
        }

        public override string ToString()
        {
            return $"{Name} - {Price} PLN";
        }
    }
}
