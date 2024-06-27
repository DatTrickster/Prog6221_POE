using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace part3_ST10228343
{
    public partial class ViewRecipeWindow : Window
    {
        // Private field to store the recipe
        private Recipe<ItemsToBeUsed> _recipe;

        // Private field to store the scale factor for ingredient quantities
        private double _scale = 1;

        // Constructor to initialize the window with a recipe
        public ViewRecipeWindow(Recipe<ItemsToBeUsed> recipe)
        {
            InitializeComponent(); // Initialize the window components
            _recipe = recipe; // Assign the recipe
            IngredientsListView.ItemsSource = _recipe.Ingredients.Values; // Set the item source for the ingredients list view
            UpdateScaledRecipe(); // Update the scaled recipe view
        }

        // Event handler for the scale combo box selection change
        private void ScaleComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ScaleComboBox.SelectedItem is ComboBoxItem selectedItem)
            {
                // Parse the selected scale value directly, assuming it is valid
                _scale = double.Parse(selectedItem.Content.ToString()); // Parse the selected scale value
                UpdateScaledRecipe(); // Update the scaled recipe view
            }
        }

        // Method to update the scaled recipe view
        private void UpdateScaledRecipe()
        {
            if (_recipe == null || _recipe.Ingredients == null)
            {
                return; // Return if the recipe or ingredients are null
            }

            // Scale the ingredient quantities and round to two decimal places
            var scaledIngredients = _recipe.Ingredients.Values.Select(i => new
            {
                i.NameOfIngrediant,
                Quantity = Math.Round(i.Quantity * _scale, 2), // Scale and round the quantity
                i.UnitOfmeasurement,
                i.DescriptionOfItem,
                Calories = Math.Round(i.Calories * _scale, 2), // Scale and round the calories
                i.FoodGroup
            }).ToList();

            IngredientsListView.ItemsSource = scaledIngredients; // Set the item source for the scaled ingredients list view

            // Calculate and display the total calories
            double totalCalories = scaledIngredients.Sum(i => i.Calories);
            TotalCaloriesTextBlock.Text = $"Total Calories: {totalCalories.ToString("0.##")}"; // Format the total calories
            if (totalCalories > 300)
            {
                // Show a warning message if total calories exceed 300
                MessageBox.Show("Warning: Scaled recipe exceeds 300 calories!", "Calorie Alert", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        // Event handler for the close button click
        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close(); // Close the window
        }
    }
}
