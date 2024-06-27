using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace part3_ST10228343
{
    public partial class ViewRecipeWindow : Window
    {
        private Recipe<ItemsToBeUsed> _recipe;
        private double _scale = 1;

        public ViewRecipeWindow(Recipe<ItemsToBeUsed> recipe)
        {
            InitializeComponent();
            _recipe = recipe;
            IngredientsListView.ItemsSource = _recipe.Ingredients.Values;
            UpdateScaledRecipe();
        }

        private void ScaleComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ScaleComboBox.SelectedItem is ComboBoxItem selectedItem)
            {
                // No need to check return value of TryParse, assume valid selection
                _scale = double.Parse(selectedItem.Content.ToString()); // Parse directly
                UpdateScaledRecipe();
            }
        }

        private void UpdateScaledRecipe()
        {
            if (_recipe == null || _recipe.Ingredients == null)
            {
                return;
            }

            var scaledIngredients = _recipe.Ingredients.Values.Select(i => new
            {
                i.NameOfIngrediant,
                Quantity = Math.Round(i.Quantity * _scale, 2), // Round to two decimal places
                i.UnitOfmeasurement,
                i.DescriptionOfItem,
                Calories = Math.Round(i.Calories * _scale, 2), // Round to two decimal places
                i.FoodGroup
            }).ToList();

            IngredientsListView.ItemsSource = scaledIngredients;

            double totalCalories = scaledIngredients.Sum(i => i.Calories);
            TotalCaloriesTextBlock.Text = $"Total Calories: {totalCalories.ToString("0.##")}"; // Format total calories
            if (totalCalories > 300)
            {
                MessageBox.Show("Warning: Scaled recipe exceeds 300 calories!", "Calorie Alert", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
