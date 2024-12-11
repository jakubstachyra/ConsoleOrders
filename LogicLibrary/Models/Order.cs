using LogicLibrary.Models.Products;

namespace LogicLibrary.Models
{
    public class Order
    {
        public Guid OrderId { get;}
        List<OrderItem> items {  get;}

        public Order()
        {
            OrderId = Guid.NewGuid();
            items = new List<OrderItem>();
        }
        public void AddProduct(Product product, int quantity)
        {
            if(product == null)
                throw new ArgumentNullException(nameof(product));

            if(quantity <= 0)
                throw new ArgumentException("Quantity must be greater than zero");

            var existingItem = items.FirstOrDefault(x => x.Product == product);
            
            if(existingItem != null)
            {
                existingItem.UpadateQuantity(existingItem.Quantity + quantity);
            }
            else
            {
                items.Add(new OrderItem(product, quantity));
            }
        }
        public void RemoveProduct(Product product)
        {
            if(product == null)
                throw new ArgumentNullException(nameof(product), "Product cannot be null");


            var existingItemToRemove = items.FirstOrDefault(x => x.Product == product);

            if(existingItemToRemove != null) { throw new ArgumentNullException("The product does not exist in the order")};
            items.Remove(existingItemToRemove);
        }
    }
}
