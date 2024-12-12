using System;
using System.Collections.Generic;
using System.Linq;
using LogicLibrary.Interfaces;
using LogicLibrary.Models.Products;

namespace LogicLibrary.Implementations
{
    public class DiscountCalculator : IDiscountCalculator
    {
        public decimal CalculateDiscount(Order order)
        {
            if (order.items == null || !order.items.Any())
            {
                return 0;
            }

            decimal totalValue = order.GetOrderValue();
            var sortedItems = order.items.OrderBy(item => item.Product.Price).ToList();
            decimal betterDiscount;

            if (sortedItems.Count == 2)
            {
                betterDiscount = 0.1m * sortedItems[0].Product.Price;
            }
            else
            {
                decimal discountOption1 = sortedItems.Count > 2 ? 0.2m * sortedItems[0].Product.Price : 0;
                decimal discountOption2 = sortedItems.Count >= 3 ? 0.1m * sortedItems[1].Product.Price : 0;

                betterDiscount = Math.Max(discountOption1, discountOption2);
            }

            if (totalValue - betterDiscount > 5000)
            {
                betterDiscount += 0.05m * (totalValue - betterDiscount);
            }

            return betterDiscount;
        }
    }
}
