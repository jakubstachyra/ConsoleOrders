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
        public void Add(Product product, int quantity)
        {
            if(product == null)
                throw new ArgumentNullException(nameof(product));

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
    }
}
