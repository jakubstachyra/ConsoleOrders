using LogicLibrary.Models.Products;

namespace LogicLibrary.Implementations
{
    public class OrderItem
    {
        public Product Product { get; set; }
        public int Quantity { get; set; }

        public OrderItem(Product product, int quantity)
        {
            Product = product ?? throw new ArgumentNullException(nameof(product));
            ValidateQuantity(quantity);
            Quantity = quantity;
        }

        public void UpadateQuantity(int newQuantity)
        {
            ValidateQuantity(newQuantity);
            Quantity = newQuantity;
        }
        public decimal GetTotalPrice()
        {
            return Product.Price * Quantity;
        }
        public override string ToString()
        {
            return $"{Product.Name} x{Quantity} = {GetTotalPrice()} PLN";
        }
        public void ValidateQuantity(int quantity)
        {
            if (quantity <= 0)
            {
                throw new ArgumentException("Quantity must be nonnegative.");
            }
        }
    }
}
