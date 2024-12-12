using LogicLibrary.Models.Products;
using NUnit.Framework;
using System.Collections.Generic;
using LogicLibrary.Interfaces;
using LogicLibrary.Implementations;

namespace LogicTests
{
    [TestFixture]
    public class DiscountCalculatorTests
    {
        private IDiscountCalculator _discountCalculator;
        private Order _order;

        [SetUp]
        public void Setup()
        {
            _discountCalculator = new DiscountCalculator();
            _order = new Order();
        }

        [Test]
        public void CalculateDiscount_ShouldReturnZero_WhenThereAreNoProductsInOrder()
        {
            decimal discount = _discountCalculator.CalculateDiscount(_order);
            Assert.That(discount, Is.EqualTo(0));
        }

        [Test]
        public void CalculateDiscount_ShouldReturnZero_WhenOnlyOneProductIsInOrderAndValueIsLessThan5000()
        {
            _order.AddProduct(new Laptop(), 1);

            decimal discount = _discountCalculator.CalculateDiscount(_order);

            Assert.That(discount, Is.EqualTo(0));
        }

        [Test]
        public void CalculateDiscount_ShouldReturnZero_WhenOnlyOneProductIsInOrderAndValueIsGreaterThan5000()
        {
            _order.AddProduct(new Laptop(), 3);

            decimal discount = _discountCalculator.CalculateDiscount(_order);
            
            //5% from 7500 = 375 PLN
            Assert.That(discount, Is.EqualTo(375));
        }

        [Test]
        public void CalculateDiscount_ShouldApply10PercentOnCheapestProduct_WhenTwoProductsExist()
        {
            _order.AddProduct(new Mouse(), 1);
            _order.AddProduct(new Keyboard(), 1); 

            decimal discount = _discountCalculator.CalculateDiscount(_order);

            // 10% from 90 PLN
            Assert.That(discount, Is.EqualTo(9));
        }
        [Test]
        public void CalculateDiscount_ShouldApply10PercentOnSecondCheapest_WhenBetterThan20PercentOnCheapest()
        {
            _order.AddProduct(new Mouse(), 1); // 90 PLN
            _order.AddProduct(new LogicLibrary.Models.Products.Monitor(), 1); //1000 PLN
            _order.AddProduct(new Laptop(), 1); // 2500 PLN

            decimal discount = _discountCalculator.CalculateDiscount(_order);

            // Option 1: 10% from 100 PLN = 100 PLN 
            // Option 2: 20% from 90 PLN = 18 PLN
            Assert.That(discount, Is.EqualTo(100));
        }

        [Test]
        public void CalculateDiscount_ShouldApply20PercentOnCheapest_WhenBetterThan10PercentOnSecondCheapest()
        {
            _order.AddProduct(new DebuggingDuck(), 1); // 66 PLN
            _order.AddProduct(new Mouse(), 1); // 90 PLN
            _order.AddProduct(new Keyboard(), 1); //120 PLN

            decimal discount = _discountCalculator.CalculateDiscount(_order);

            // Option 1: 10% from 90 PLN = 9 PLN
            // Option 2: 20% from 66 PLN = 13,2 PLN
            Assert.That(discount, Is.EqualTo(13.2m).Within(0.1m)); ;
        }

        [Test]
        public void CalculateDiscount_ShouldCombine5PercentAnd10PercentDiscounts_WhenApplicable()
        {
            _order.AddProduct(new Laptop(), 2); 
            _order.AddProduct(new Mouse(), 1); 

            decimal discount = _discountCalculator.CalculateDiscount(_order);

            // 10% from 90 PLN = 9 PLN
            // Value after discount: 5000 + (90 - 9) = 5081 PLN
            // 5% from 5081 PLN = 254.05 PLN
            // Combined discount: 9 + 254.05 = 263.05 PLN
            Assert.That(discount, Is.EqualTo(263.05m).Within(0.01m));
        }

        [Test]
        public void CalculateDiscount_ShouldChoose20PercentOnCheapest_WhenBetterThan10PercentOnSecondCheapestAnd5Percent()
        {
            _order.AddProduct(new Laptop(), 2); // 2 x 2500 PLN = 5000 PLN
            _order.AddProduct(new Keyboard(), 1); // 120 PLN
            _order.AddProduct(new Mouse(), 1); // 90 PLN

            decimal discount = _discountCalculator.CalculateDiscount(_order);

            // Option 1: 20% from 90 PL = 18 PLN
            // Total value after the discount: (2 x 2500) + 120 + (90 - 18) = 5192 PLN
            // Additional 5% discount on 5192 PLN = 259.6 PLN
            // Total discount: 18 + 259.6 = 277.6 PLN

            // Option 2: 10% from 120 PLN = 12 PLN
            // Total value after the discount: (2 x 2500) + (120 - 12) + 90 = 5198 PLN
            // Additional 5% discount on 5198 PLN = 259.9 PLN
            // Total discount: 12 + 259.9 = 271.9 PLN

            // Expected result: Option 1 is better (277.6 PLN)
            Assert.That(discount, Is.EqualTo(277.6m).Within(0.01m));
        }

        [Test]
        public void CalculateDiscount_ShouldChoose10PercentOnSecondCheapest_WhenBetterThan20PercentOnCheapestAnd5Percent()
        {
            _order.AddProduct(new Laptop(), 2); // 2 x 2500 PLN = 5000 PLN
            _order.AddProduct(new LogicLibrary.Models.Products.Monitor(), 1); // 1000 PLN
            _order.AddProduct(new Mouse(), 1); // 90 PLN

            decimal discount = _discountCalculator.CalculateDiscount(_order);


            // Option 1: 20% from 90 PLN = 18 PLN
            // Total value after the discount: 5000 + 1000 + (90 - 18) = 6072
            // Additional 5% discount on 6072 = 303,6 PLN
            // Total discount: 18 + 303,6 = 321,6

            // Option2: 10% from 1000 PLN = 100 PLN
            // Total value after the discount: 5000 + (1000 - 100) + 90 = 5990
            // Additional 5% discount on 5990 = 299,5 PLN
            // Total discount: 100 + 299,5 = 399,5 PLN

            Assert.That(discount, Is.EqualTo(399.5m).Within(0.01m));
        }


    }
}
