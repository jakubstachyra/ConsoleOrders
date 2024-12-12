using LogicLibrary.Implementations;
using LogicLibrary.Models.Products;

namespace LogicTests
{
    public class AddProductTests
    {
        private Order _order;

        [SetUp]
        public void Setup()
        {
            _order = new Order();
        }

        [Test]
        public void AddProduct_ShouldThrowAnException_WhenProductIsNull()
        {
            Product? product = null;
            int quantity = 3;

            var exeption = Assert.Throws<ArgumentNullException>(() => _order.AddProduct(product!, quantity));
            Assert.That(exeption.ParamName, Is.EqualTo(nameof(product)));
        }
        [Test]
        public void AddProduct_ShouldThrownAnExeption_WhenQuantityIsNonPositive()
        {
            Product product = new Laptop();
            int quantity = -1;

            var exception = Assert.Throws<ArgumentException>(() => _order.AddProduct(product, quantity));
            Assert.That(exception.Message, Does.Contain("Quantity must be greater than zero"));
        }
        [Test]
        public void AddProduct_ShouldAddProduct_WhenProductExistsAndQuntityIsPositive()
        {
            Mouse product = new Mouse();
            int quantity = 3;

            _order.AddProduct(product,quantity);

            Assert.That(_order.items.Count, Is.EqualTo(1));
            Assert.That(_order.items[0].Quantity, Is.EqualTo(3));
            Assert.That(_order.items[0].Product, Is.SameAs(product!));
        }
        [Test]
        public void AddProduct_ShouldIncreaseQuantity_WhenProductAlreadyExists()
        {
            var product = new Laptop();
            int quantity = 1;

            _order.AddProduct(product, quantity);

            _order.AddProduct(product, quantity);

            Assert.That(_order.items.Count, Is.EqualTo(1));
            Assert.That(_order.items[0].Quantity, Is.EqualTo(2));
        }
    }
}