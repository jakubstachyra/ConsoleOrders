using LogicLibrary.Models.Products;
using LogicLibrary.Models;

namespace LogicTests
{
    [TestFixture]
    public class OrderTests
    {
        private Order _order;

        [SetUp]
        public void Setup()
        {
            _order = new Order();
        }

        [Test]
        public void GetOrderValue_ShouldReturnZero_WhenOrderIsEmpty()
        {
            float orderValue = _order.GetOrderValue();

            Assert.That(orderValue, Is.EqualTo(0f));
        }

        [Test]
        public void GetOrderValue_ShouldReturnCorrectValue_WhenOrderHasSingleItem()
        {
            Product product = new Laptop();
            _order.AddProduct(product, 2);

            float orderValue = _order.GetOrderValue();

            Assert.That(orderValue, Is.EqualTo(5000f));
        }

        [Test]
        public void GetOrderValue_ShouldReturnCorrectValue_WhenOrderHasMultipleItems()
        {
            Product laptop = new Laptop();
            Product mouse = new Mouse();

            int laptopQuantity = 1;
            int mouseQuantity = 3;

            _order.AddProduct(laptop, laptopQuantity);
            _order.AddProduct(mouse, mouseQuantity);

            float orderValue = _order.GetOrderValue();

            Assert.That(orderValue, Is.EqualTo(2770f));
        }
    }
}
