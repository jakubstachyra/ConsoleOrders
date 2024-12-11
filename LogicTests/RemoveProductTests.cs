using LogicLibrary.Models;
using LogicLibrary.Models.Products;

namespace LogicTests
{
    [TestFixture]
    public class RemoveProductTests
    {
        private Order _order;

        [SetUp]
        public void SetUp()
        {
            _order = new Order();
        }
        [Test]
        public void RemoveProduct_ShouldRemoveProduct_WhenProductExists() 
        {
            Product product = new Keyboard();
            int quantity = 1;

            _order.AddProduct(product, quantity);

            Assert.That(_order.items.Count, Is.EqualTo(quantity));

            _order.RemoveProduct(product);

            Assert.That(_order.items.Count, Is.EqualTo(0));

        }
        [Test]
        public void RemoveProduct_ShouldThrowArgumentNullException_WhenProductIsNull()
        {
            Product? product = null!;

            var exception = Assert.Throws<ArgumentNullException>(() => _order.RemoveProduct(product));
            Assert.That(exception.ParamName, Is.EqualTo("product"));
            Assert.That(exception.Message, Does.Contain("Product cannot be null"));
        }
        [Test]
        public void RemoveProduct_ShouldThrowArgumentNullException_WhenProductIsNotInOrder()
        {
            Product product = new Mouse();

            var exception = Assert.Throws<ArgumentNullException>(() => _order.RemoveProduct(product));
            Assert.That(exception.Message, Does.Contain("The product does not exist in the order"));
        }
    }
}
