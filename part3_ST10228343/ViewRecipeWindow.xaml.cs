using System;
using System.Collections.Generic;
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
    public partial class ViewRecipeWindow : Window
    {
        private Recipe<ItemsToBeUsed> recipe;

        public ViewRecipeWindow(Recipe<ItemsToBeUsed> recipe)
        {
            InitializeComponent();
            this.recipe = recipe;
            DataContext = recipe;
            IngredientsListView.ItemsSource = recipe.Ingredients.Values.ToList();
            TotalCaloriesTextBlock.Text = $"Total Calories: {recipe.TotalCalories(i => i.Calories)}";
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}