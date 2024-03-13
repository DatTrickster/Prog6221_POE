
using System;

namespace ShoppingCartApp
{
    // Derived class for electronics products
    public class ElectronicsProduct : Product
    {
        private readonly string brand;
        private readonly string model;

        // Properties
        public string Brand { get { return brand; } }
        public string Model { get { return model; } }

        // Constructor
        public ElectronicsProduct(string name, double price, ProductCategory category, string brand, string model)
            : base(name, price, category)
        {
            this.brand = brand;
            this.model = model;
        }

        // Override method to get information about the electronics product
        public override void GetInfo()
        {
            base.GetInfo();
            Console.WriteLine($"Brand: {brand}, Model: {model}");
        }
    }
}
