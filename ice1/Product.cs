using System;

namespace ShoppingCartApp
{
    // Enum representing different product categories
    public enum ProductCategory
    {
        Clothing,
        Electronics,
        Home,
        Beauty,
        Groceries
    }

    // Base class for all products
    public class Product
    {
        private string name;
        private double price;
        private ProductCategory category;

        // Properties
        public string Name { get { return name; } }
        public double Price { get { return price; } }
        public ProductCategory Category { get { return category; } }

        // Constructor
        public Product(string name, double price, ProductCategory category)
        {
            this.name = name;
            this.price = price;
            this.category = category;
        }

        // Method to get information about the product
        public virtual void GetInfo()
        {
            Console.WriteLine($"Name: {name}, Price: {price}, Category: {category}");
        }
    }
}
