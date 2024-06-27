using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using OxyPlot;
using OxyPlot.Series;

namespace part3_ST10228343
{
    public partial class SelectRecipesWindow : Window
    {
        // Collection to store the recipes
        private ObservableCollection<Recipe<ItemsToBeUsed>> _recipes;

        // Property to store the PieChart model
        public PlotModel PieChartModel { get; private set; }

        // Constructor to initialize the window with a collection of recipes
        public SelectRecipesWindow(ObservableCollection<Recipe<ItemsToBeUsed>> recipes)
        {
            InitializeComponent(); // Initialize the window components
            _recipes = recipes; // Assign the recipes collection
            RecipesListBox.ItemsSource = _recipes.Select(r => r.Name).ToList(); // Populate the list box with recipe names
        }

        // Event handler for the "Show Pie Chart" button click
        private void ShowPieChartButton_Click(object sender, RoutedEventArgs e)
        {
            var selectedRecipes = RecipesListBox.SelectedItems.Cast<string>().ToList(); // Get the selected recipes
            if (selectedRecipes.Count == 0)
            {
                MessageBox.Show("Please select at least one recipe."); // Show a message if no recipe is selected
                return;
            }

            // Dictionary to aggregate ingredients by food group
            var aggregatedIngredients = new Dictionary<string, double>();
            foreach (var recipeName in selectedRecipes)
            {
                var recipe = _recipes.First(r => r.Name == recipeName); // Find the recipe by name
                foreach (var ingredient in recipe.Ingredients.Values)
                {
                    // Aggregate ingredient quantities by food group
                    if (aggregatedIngredients.ContainsKey(ingredient.FoodGroup))
                    {
                        aggregatedIngredients[ingredient.FoodGroup] += ingredient.Quantity;
                    }
                    else
                    {
                        aggregatedIngredients[ingredient.FoodGroup] = ingredient.Quantity;
                    }
                }
            }

            // Create and configure the PieChart model
            PieChartModel = new PlotModel { Title = "Food Group Distribution" };
            var pieSeries = new PieSeries();
            foreach (var group in aggregatedIngredients)
            {
                pieSeries.Slices.Add(new PieSlice(group.Key, group.Value)); // Add slices to the pie chart
            }
            PieChartModel.Series.Add(pieSeries);

            PieChart.Model = PieChartModel; // Update the PieChart with the model
        }

        // Event handler for the "Cancel" button click
        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close(); // Close the window
        }
    }
}
