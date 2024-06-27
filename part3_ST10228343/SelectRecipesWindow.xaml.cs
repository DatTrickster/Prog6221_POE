using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using OxyPlot;
using OxyPlot.Series;
namespace part3_ST10228343
{
    public partial class SelectRecipesWindow : Window
    {
        private ObservableCollection<Recipe<ItemsToBeUsed>> _recipes;
        public PlotModel PieChartModel { get; private set; }

        public SelectRecipesWindow(ObservableCollection<Recipe<ItemsToBeUsed>> recipes)
        {
            InitializeComponent();
            _recipes = recipes;
            RecipesListBox.ItemsSource = _recipes.Select(r => r.Name).ToList();
        }

        private void ShowPieChartButton_Click(object sender, RoutedEventArgs e)
        {
            var selectedRecipes = RecipesListBox.SelectedItems.Cast<string>().ToList();
            if (selectedRecipes.Count == 0)
            {
                MessageBox.Show("Please select at least one recipe.");
                return;
            }

            var aggregatedIngredients = new Dictionary<string, double>();
            foreach (var recipeName in selectedRecipes)
            {
                var recipe = _recipes.First(r => r.Name == recipeName);
                foreach (var ingredient in recipe.Ingredients.Values)
                {
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

            PieChartModel = new PlotModel { Title = "Food Group Distribution" };
            var pieSeries = new PieSeries();
            foreach (var group in aggregatedIngredients)
            {
                pieSeries.Slices.Add(new PieSlice(group.Key, group.Value));
            }
            PieChartModel.Series.Add(pieSeries);

            PieChart.Model = PieChartModel;
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}