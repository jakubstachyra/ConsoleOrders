﻿using LogicLibrary.Models.Products;

namespace LogicLibrary.Models
{
    public class OrderItem
    {
        public Product Product { get; set; }
        public int Quantity { get; set; }

        public OrderItem(Product product, int quantity)
        {
            if(quantity <= 0)
            {
                throw new ArgumentException("Quantity must be nonnegative.");
            }
            Product = product ?? throw new ArgumentNullException(nameof(product));
            Quantity = quantity;
        }

        public void UpadateQuantity(int newQuantity)
        {
            if(newQuantity <= 0)
            {
                throw new ArgumentException("Quantity must be nonnegative.");
            }

            Quantity = newQuantity;
        }
        public float GetTotalPrice()
        {
            return Product.Price * Quantity;
        }
        public override string ToString()
        {
            return $"{Product.Name} x{Quantity} = {GetTotalPrice()} PLN";
        }
    }
}