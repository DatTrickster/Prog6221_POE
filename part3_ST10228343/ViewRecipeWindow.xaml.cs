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
                double.TryParse(selectedItem.Content.ToString(), out _scale);
                UpdateScaledRecipe();
            }
        }

        private void UpdateScaledRecipe()
        {
            var scaledIngredients = _recipe.Ingredients.Values.Select(i => new
            {
                i.NameOfIngrediant,
                Quantity = i.Quantity * _scale,
                i.UnitOfmeasurement,
                i.DescriptionOfItem,
                Calories = i.Calories * _scale,
                i.FoodGroup
            }).ToList();

            IngredientsListView.ItemsSource = scaledIngredients;

            double totalCalories = scaledIngredients.Sum(i => i.Calories);
            TotalCaloriesTextBlock.Text = $"Total Calories: {totalCalories}";
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
