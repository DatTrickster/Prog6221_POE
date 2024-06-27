using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace part3_ST10228343
{
    public partial class AddRecipeWindow : Window
    {
        // Collection to store the existing recipes
        private ObservableCollection<Recipe<ItemsToBeUsed>> _recipes;

        // Collection to store the ingredients for the new recipe
        private ObservableCollection<ItemsToBeUsed> _ingredients;

        // Constructor to initialize the window with a collection of recipes
        public AddRecipeWindow(ObservableCollection<Recipe<ItemsToBeUsed>> recipes)
        {
            InitializeComponent(); // Initialize the window components
            _recipes = recipes; // Assign the recipes collection
            _ingredients = new ObservableCollection<ItemsToBeUsed>(); // Initialize the ingredients collection
            IngredientsListView.ItemsSource = _ingredients; // Set the item source for the ingredients list view
        }

        // Event handler for the "Add" button click
        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(RecipeNameTextBox.Text))
            {
                MessageBox.Show("Please enter a recipe name."); // Show a message if the recipe name is empty
                return;
            }

            var newRecipe = new Recipe<ItemsToBeUsed>(RecipeNameTextBox.Text); // Create a new recipe with the entered name
            foreach (var ingredient in _ingredients)
            {
                newRecipe.AddIngredient(ingredient.NameOfIngrediant, ingredient); // Add each ingredient to the new recipe
            }
            _recipes.Add(newRecipe); // Add the new recipe to the recipes collection
            this.Close(); // Close the window
        }

        // Event handler for the "Cancel" button click
        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close(); // Close the window
        }

        // Event handler for the "Add Ingredient" button click
        private void AddIngredientButton_Click(object sender, RoutedEventArgs e)
        {
            var addIngredientWindow = new AddIngredientWindow(_ingredients); // Create a new AddIngredientWindow
            addIngredientWindow.ShowDialog(); // Show the AddIngredientWindow as a dialog
        }
    }
}
