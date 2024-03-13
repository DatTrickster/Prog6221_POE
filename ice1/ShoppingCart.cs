
using System;

namespace ShoppingCartApp
{
    // Class representing a shopping cart
    public class ShoppingCart
    {
        private Product[] products;
        private int itemCount;

        // Properties
        public Product[] Products { get { return products; } }
        public int ItemCount { get { return itemCount; } }

        // Constructor
        public ShoppingCart(int capacity)
        {
            products = new Product[capacity];
            itemCount = 0;
        }

        // Method to add a product to the shopping cart
        public void AddProduct(Product product)
        {
            if (itemCount < products.Length)
            {
                products[itemCount] = product;
                itemCount++;
            }
            else
            {
                Console.WriteLine("Shopping cart is full!");
            }
        }

        // Method to remove a product from the shopping cart
        public void RemoveProduct(Product product)
        {
            for (int i = 0; i < itemCount; i++)
            {
                if (products[i] == product)
                {
                    for (int j = i; j < itemCount - 1; j++)
                    {
                        products[j] = products[j + 1];
                    }
                    products[itemCount - 1] = null;
                    itemCount--;
                    return;
                }
            }
            Console.WriteLine("Product not found in the shopping cart!");
        }
    }
}
