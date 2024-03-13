using ShoppingCartApp;

public class Program
{
    // Main method
    static void Main(string[] args)
    {
        // Instantiate products
        ClothingProduct shirt = new ClothingProduct("Shirt", 25.99, ProductCategory.Clothing, "Large", "Blue");
        ElectronicsProduct phone = new ElectronicsProduct("Smartphone", 499.99, ProductCategory.Electronics, "Apple", "iPhone 13");

        // Instantiate shopping cart
        ShoppingCart cart = new ShoppingCart(5);

        // Add products to the shopping cart
        cart.AddProduct(shirt);
        cart.AddProduct(phone);

        // Display contents of the shopping cart
        Console.WriteLine("Shopping Cart Contents:");
        foreach (Product product in cart.Products)
        {
            if (product != null)
                product.GetInfo();
        }

        // Remove a product from the shopping cart
        cart.RemoveProduct(shirt);

        // Display updated contents of the shopping cart
        Console.WriteLine("\nUpdated Shopping Cart Contents:");
        foreach (Product product in cart.Products)
        {
            if (product != null)
                product.GetInfo();
        }
    }
}
