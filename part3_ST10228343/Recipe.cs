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
            if (name == null)
            {
                throw new ArgumentNullException(nameof(name), "Ingredient name cannot be null.");
            }

            if (ingredient == null)
            {
                throw new ArgumentNullException(nameof(ingredient), "Ingredient object cannot be null.");
            }

            // Check if the ingredient name already exists
            while (Ingredients.ContainsKey(name))
            {
                Console.WriteLine($"An ingredient with the name '{name}' already exists in the recipe. Please enter a different name:");
                string newName = Console.ReadLine();

                if (!string.IsNullOrWhiteSpace(newName))
                {
                    name = newName;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a valid name.");
                }
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
