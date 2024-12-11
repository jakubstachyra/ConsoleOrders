namespace LogicLibrary.Models
{
    public abstract class Product
    {
        public string Name { get; set; }
        public float Price { get; set; }

        protected Product(string name, float price)
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
