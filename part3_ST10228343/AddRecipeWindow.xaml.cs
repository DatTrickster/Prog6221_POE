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
        private ObservableCollection<Recipe<ItemsToBeUsed>> _recipes;
        private ObservableCollection<ItemsToBeUsed> _ingredients;

        public AddRecipeWindow(ObservableCollection<Recipe<ItemsToBeUsed>> recipes)
        {
            InitializeComponent();
            _recipes = recipes;
            _ingredients = new ObservableCollection<ItemsToBeUsed>();
            IngredientsListView.ItemsSource = _ingredients;
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(RecipeNameTextBox.Text))
            {
                MessageBox.Show("Please enter a recipe name.");
                return;
            }

            var newRecipe = new Recipe<ItemsToBeUsed>(RecipeNameTextBox.Text);
            foreach (var ingredient in _ingredients)
            {
                newRecipe.AddIngredient(ingredient.NameOfIngrediant, ingredient);
            }
            _recipes.Add(newRecipe);
            this.Close();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void AddIngredientButton_Click(object sender, RoutedEventArgs e)
        {
            var addIngredientWindow = new AddIngredientWindow(_ingredients);
            addIngredientWindow.ShowDialog();
        }
    }
}