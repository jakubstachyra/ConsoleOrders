using LogicLibrary.Implementations;
using LogicLibrary.Interfaces;
using System;
using System.Linq;

public class DiscountCalculator : IDiscountCalculator
{
    public decimal CalculateDiscount(Order order)
    {
        if (order.items == null || !order.items.Any())
        {
            return 0m;
        }

        decimal totalValue = order.GetOrderValue();
        var sortedItems = order.items.OrderBy(item => item.Product.Price).ToList();

        int count = sortedItems.Count;

        if (count == 1)
        {
            return totalValue > 5000 ? 0.05m * totalValue : 0m;
        }

        if (count == 2)
        {
            var cheapestLine = sortedItems[0];
            decimal lineDiscount = 0.1m * cheapestLine.Product.Price * cheapestLine.Quantity;

            decimal newTotalAfterLineDiscount = totalValue - lineDiscount;
            decimal finalDiscount = lineDiscount;

            if (newTotalAfterLineDiscount > 5000)
            {
                finalDiscount += 0.05m * newTotalAfterLineDiscount;
            }

            return finalDiscount;
        }

        // Sytuacja, gdy mamy więcej niż dwa produkty w zamówieniu
        // Możliwe opcje zniżek:
        // Option1: 20% zniżki od najtańszego produktu
        // Option2: 10% zniżki od drugiego najtańszego produktu
        // Po wyliczeniu zniżki liniowej sprawdzamy czy wartość > 5000, jeśli tak to dodatkowe 5%.
        var cheapestLineItem = sortedItems[0];
        var secondCheapestLineItem = sortedItems[1];

        // Opcja 1: 20% od najtańszego produktu
        decimal option1LineDiscount = 0.2m * cheapestLineItem.Product.Price * cheapestLineItem.Quantity;
        decimal option1NewTotal = totalValue - option1LineDiscount;
        decimal option1FinalDiscount = option1LineDiscount;
        if (option1NewTotal > 5000)
        {
            option1FinalDiscount += 0.05m * option1NewTotal;
        }

        // Opcja 2: 10% od drugiego najtańszego produktu
        decimal option2LineDiscount = 0.1m * secondCheapestLineItem.Product.Price * secondCheapestLineItem.Quantity;
        decimal option2NewTotal = totalValue - option2LineDiscount;
        decimal option2FinalDiscount = option2LineDiscount;
        if (option2NewTotal > 5000)
        {
            option2FinalDiscount += 0.05m * option2NewTotal;
        }

        // Wybierz lepszą opcję
        return Math.Max(option1FinalDiscount, option2FinalDiscount);
    }
}
