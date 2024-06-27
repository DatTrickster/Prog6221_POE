using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;

namespace part3_ST10228343
{
    public partial class AddIngredientWindow : Window
    {
        // Collection to store the ingredients
        private ObservableCollection<ItemsToBeUsed> _ingredients;

        // Constructor to initialize the window with a collection of ingredients
        public AddIngredientWindow(ObservableCollection<ItemsToBeUsed> ingredients)
        {
            InitializeComponent(); // Initialize the window components
            _ingredients = ingredients; // Assign the ingredients collection
        }

        // Event handler for the "Add Ingredient" button click
        private void AddIngredientButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(IngredientNameTextBox.Text) ||
                string.IsNullOrWhiteSpace(QuantityTextBox.Text) ||
                string.IsNullOrWhiteSpace(UnitTextBox.Text) ||
                string.IsNullOrWhiteSpace(CaloriesTextBox.Text) ||
                string.IsNullOrWhiteSpace(FoodGroupTextBox.Text))
            {
                MessageBox.Show("Please fill in all fields."); // Show a message if any field is empty
                return;
            }

            // Validate that quantity and calories are valid numbers
            if (!double.TryParse(QuantityTextBox.Text, out double quantity) || !double.TryParse(CaloriesTextBox.Text, out double calories))
            {
                MessageBox.Show("Please enter valid numbers for quantity and calories."); // Show a message if quantity or calories are invalid
                return;
            }

            // Create a new ingredient with the entered details
            var ingredient = new ItemsToBeUsed
            {
                NameOfIngrediant = IngredientNameTextBox.Text,
                Quantity = quantity,
                UnitOfmeasurement = UnitTextBox.Text,
                DescriptionOfItem = DescriptionTextBox.Text,
                Calories = calories,
                FoodGroup = FoodGroupTextBox.Text
            };

            // Check if the ingredient already exists
            if (IngredientAlreadyExists(ingredient.NameOfIngrediant))
            {
                MessageBox.Show($"An ingredient with the name '{ingredient.NameOfIngrediant}' already exists."); // Show a message if the ingredient exists
                return;
            }

            _ingredients.Add(ingredient); // Add the new ingredient to the collection
            this.Close(); // Close the window
        }

        // Method to check if an ingredient already exists in the collection
        private bool IngredientAlreadyExists(string ingredientName)
        {
            return _ingredients.Any(i => i.NameOfIngrediant.Equals(ingredientName, StringComparison.OrdinalIgnoreCase)); // Check for existence ignoring case
        }

        // Event handler for the "Cancel" button click
        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close(); // Close the window
        }
    }
}
