using System;

namespace part3_ST10228343
{
    public class ItemsToBeUsed
    {
        // Static property to store the length of the items
        public static int Length { get; internal set; }

        // Property to store the name of the ingredient
        public string NameOfIngrediant { get; set; } = string.Empty;

        // Property to store the quantity of the ingredient
        public double Quantity { get; set; }

        // Property to store the unit of measurement for the ingredient
        public string UnitOfmeasurement { get; set; } = string.Empty;

        // Property to store the description of the item
        public string DescriptionOfItem { get; set; } = string.Empty;

        // Property to store the number of calories in the ingredient
        public double Calories { get; set; }

        // Property to store the food group of the ingredient
        public string FoodGroup { get; set; } = string.Empty;
    }
}
