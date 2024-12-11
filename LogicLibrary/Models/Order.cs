namespace LogicLibrary.Models
{
    public class Order
    {
        List<OrderItem> items;

        public Order()
        {
            items = new List<OrderItem>();
        }
        public void Add(OrderItem item)
        {
            items.Add(item);
        }
    }
}
