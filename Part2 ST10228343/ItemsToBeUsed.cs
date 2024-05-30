using System;

namespace Part2_ST10228343
{
    // Class representing an item to be used in a recipe
    public class ItemsToBeUsed
    {
        // Static property to store the number of items
        public static int Length { get; internal set; }

        // Name of the ingredient
        public string NameOfIngrediant { get; set; } = string.Empty;

        // Quantity of the ingredient
        public double Quantity { get; set; }

        // Unit of measurement for the quantity (e.g., grams, cups)
        public string UnitOfmeasurement { get; set; } = string.Empty;

        // Description of the item
        public string DescriptionOfItem { get; set; } = string.Empty;

        // Caloric value of the ingredient
        public double Calories { get; set; }

        // Food group to which the ingredient belongs (e.g., protein, vegetable)
        public string FoodGroup { get; set; } = string.Empty;
    }
}
