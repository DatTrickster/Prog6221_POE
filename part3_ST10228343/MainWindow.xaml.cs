using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace part3_ST10228343
{
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        private ObservableCollection<Recipe<ItemsToBeUsed>> _recipes = new ObservableCollection<Recipe<ItemsToBeUsed>>();
        private ObservableCollection<string> _foodGroups = new ObservableCollection<string>();

        public ObservableCollection<Recipe<ItemsToBeUsed>> Recipes
        {
            get => _recipes;
            set
            {
                _recipes = value;
                OnPropertyChanged(nameof(Recipes));
            }
        }

        public ObservableCollection<string> FoodGroups
        {
            get => _foodGroups;
            set
            {
                _foodGroups = value;
                OnPropertyChanged(nameof(FoodGroups));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public MainWindow()
        {
            InitializeComponent();
            RecipeListView.ItemsSource = Recipes;
            FoodGroupFilterComboBox.ItemsSource = FoodGroups;
            RecipeHandler.RecipeExceedsCaloriesEvent += OnRecipeExceedsCalories;
        }

        private void AddRecipe_Click(object sender, RoutedEventArgs e)
        {
            var addRecipeWindow = new AddRecipeWindow(Recipes);
            addRecipeWindow.ShowDialog();
            UpdateFoodGroupFilterOptions();
        }

        private void ViewRecipe_Click(object sender, RoutedEventArgs e)
        {
            if (RecipeListView.SelectedItem is Recipe<ItemsToBeUsed> selectedRecipe)
            {
                var viewRecipeWindow = new ViewRecipeWindow(selectedRecipe);
                viewRecipeWindow.ShowDialog();
            }
            else
            {
                MessageBox.Show("Please select a recipe to view.");
            }
        }

        private void DeleteRecipe_Click(object sender, RoutedEventArgs e)
        {
            if (RecipeListView.SelectedItem is Recipe<ItemsToBeUsed> selectedRecipe)
            {
                Recipes.Remove(selectedRecipe);
                UpdateFoodGroupFilterOptions();
                MessageBox.Show("Recipe deleted successfully.");
            }
            else
            {
                MessageBox.Show("Please select a recipe to delete.");
            }
        }

        private void ClearAllRecipes_Click(object sender, RoutedEventArgs e)
        {
            Recipes.Clear();
            UpdateFoodGroupFilterOptions();
            MessageBox.Show("All recipes have been cleared.");
        }

        private void ApplyFilter_Click(object sender, RoutedEventArgs e)
        {
            var filteredRecipes = Recipes.AsEnumerable();

            if (!string.IsNullOrEmpty(IngredientFilterTextBox.Text))
            {
                string ingredient = IngredientFilterTextBox.Text.ToLower();
                filteredRecipes = filteredRecipes.Where(r => r.Ingredients.Values.Any(i => i.NameOfIngrediant.ToLower().Contains(ingredient)));
            }

            if (FoodGroupFilterComboBox.SelectedItem != null)
            {
                string foodGroup = FoodGroupFilterComboBox.SelectedItem.ToString();
                filteredRecipes = filteredRecipes.Where(r => r.Ingredients.Values.Any(i => i.FoodGroup == foodGroup));
            }

            if (double.TryParse(MaxCaloriesFilterTextBox.Text, out double maxCalories))
            {
                filteredRecipes = filteredRecipes.Where(r => r.TotalCalories(i => i.Calories) <= maxCalories);
            }

            RecipeListView.ItemsSource = new ObservableCollection<Recipe<ItemsToBeUsed>>(filteredRecipes);
        }

        private void ClearFilter_Click(object sender, RoutedEventArgs e)
        {
            IngredientFilterTextBox.Clear();
            FoodGroupFilterComboBox.SelectedIndex = -1;
            MaxCaloriesFilterTextBox.Clear();
            RecipeListView.ItemsSource = Recipes;
        }

        private void UpdateFoodGroupFilterOptions()
        {
            var foodGroups = Recipes.SelectMany(r => r.Ingredients.Values.Select(i => i.FoodGroup)).Distinct().ToList();
            FoodGroups.Clear();
            foreach (var group in foodGroups)
            {
                FoodGroups.Add(group);
            }
        }

        private void OnRecipeExceedsCalories()
        {
            MessageBox.Show("Warning: Recipe exceeds 300 calories!", "Calorie Alert", MessageBoxButton.OK, MessageBoxImage.Warning);
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}