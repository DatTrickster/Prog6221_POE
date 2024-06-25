using System;
using System.Collections.Generic;

namespace part3_ST10228343
{
    public class Recipe<T>
    {
        public string Name { get; set; }
        public Dictionary<string, T> Ingredients { get; set; }

        public Recipe(string name)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Ingredients = new Dictionary<string, T>();
        }

        public void AddIngredient(string name, T ingredient)
        {
            if (name == null || ingredient == null)
            {
                throw new ArgumentNullException("Ingredient name or object cannot be null.");
            }
            Ingredients.Add(name, ingredient);
        }

        public double TotalCalories(Func<T, double> calorieSelector)
        {
            double totalCalories = 0;
            foreach (var ingredient in Ingredients.Values)
            {
                totalCalories += calorieSelector(ingredient);
            }
            return totalCalories;
        }
    }
}
