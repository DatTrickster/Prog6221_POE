using System;

namespace Part2_ST10228343
{
    public class ItemsToBeUsed
    {
        public static int Length { get; internal set; }
        public string NameOfIngrediant { get; set; } = string.Empty;
        public double Quantity { get; set; }
        public string UnitOfmeasurement { get; set; } = string.Empty;
        public string DescriptionOfItem { get; set; } = string.Empty;
        public double Calories { get; set; }
        public string FoodGroup { get; set; } = string.Empty;
    }
}
