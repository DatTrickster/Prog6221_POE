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

    public partial class AddIngredientWindow : Window
    {
        private ObservableCollection<ItemsToBeUsed> _ingredients;

        public AddIngredientWindow(ObservableCollection<ItemsToBeUsed> ingredients)
        {
            InitializeComponent();
            _ingredients = ingredients;
        }

        private void AddIngredientButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(IngredientNameTextBox.Text) ||
                string.IsNullOrWhiteSpace(QuantityTextBox.Text) ||
                string.IsNullOrWhiteSpace(UnitTextBox.Text) ||
                string.IsNullOrWhiteSpace(CaloriesTextBox.Text) ||
                string.IsNullOrWhiteSpace(FoodGroupTextBox.Text))
            {
                MessageBox.Show("Please fill in all fields.");
                return;
            }

            if (!double.TryParse(QuantityTextBox.Text, out double quantity) || !double.TryParse(CaloriesTextBox.Text, out double calories))
            {
                MessageBox.Show("Please enter valid numbers for quantity and calories.");
                return;
            }

            var ingredient = new ItemsToBeUsed
            {
                NameOfIngrediant = IngredientNameTextBox.Text,
                Quantity = quantity,
                UnitOfmeasurement = UnitTextBox.Text,
                DescriptionOfItem = DescriptionTextBox.Text,
                Calories = calories,
                FoodGroup = FoodGroupTextBox.Text
            };

            _ingredients.Add(ingredient);
            this.Close();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}