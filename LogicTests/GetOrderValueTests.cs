using LogicLibrary.Models.Products;
using LogicLibrary.Implementations;

namespace LogicTests
{
    [TestFixture]
    public class GetOrderValueTests
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
            decimal orderValue = _order.GetOrderValue();

            Assert.That(orderValue, Is.EqualTo(0f));
        }

        [Test]
        public void GetOrderValue_ShouldReturnCorrectValue_WhenOrderHasSingleItem()
        {
            Product product = new Laptop();
            _order.AddProduct(product, 2);

            decimal orderValue = _order.GetOrderValue();

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

            decimal orderValue = _order.GetOrderValue();

            Assert.That(orderValue, Is.EqualTo(2770f));
        }
    }
}
