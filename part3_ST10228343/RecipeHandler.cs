using System;
using System.Collections.Generic;

namespace part3_ST10228343
{
    // Delegate for handling the event when a recipe exceeds the calorie limit
    public delegate void RecipeExceedsCaloriesHandler();

    public static class RecipeHandler
    {
        // Dictionary to store recipes with their names as keys
        private static Dictionary<string, Recipe<ItemsToBeUsed>> recipes = new Dictionary<string, Recipe<ItemsToBeUsed>>();

        // Event triggered when a recipe exceeds the calorie limit
        public static event RecipeExceedsCaloriesHandler RecipeExceedsCaloriesEvent;

        // Method to add a recipe
        public static void AddRecipe(Recipe<ItemsToBeUsed> recipe)
        {
            if (recipe == null)
                throw new ArgumentNullException(nameof(recipe)); // Throw an exception if the recipe is null

            double totalCalories = recipe.TotalCalories(i => i.Calories); // Calculate total calories of the recipe
            if (totalCalories > 300)
            {
                RecipeExceedsCaloriesEvent?.Invoke(); // Invoke the event if calories exceed 300
            }

            recipes.Add(recipe.Name, recipe); // Add the recipe to the dictionary
        }

        // Method to delete a recipe by name
        public static void DeleteRecipe(string recipeName)
        {
            if (recipes.ContainsKey(recipeName))
            {
                recipes.Remove(recipeName); // Remove the recipe if it exists
            }
            else
            {
                throw new KeyNotFoundException($"Recipe '{recipeName}' not found."); // Throw an exception if the recipe is not found
            }
        }

        // Method to get a list of recipe names
        public static List<string> GetRecipeNames()
        {
            return new List<string>(recipes.Keys); // Return a list of recipe names
        }

        // Method to get a recipe by name
        public static Recipe<ItemsToBeUsed> GetRecipeByName(string recipeName)
        {
            if (recipes.TryGetValue(recipeName, out Recipe<ItemsToBeUsed> recipe))
            {
                return recipe; // Return the recipe if found
            }
            else
            {
                throw new KeyNotFoundException($"Recipe '{recipeName}' not found."); // Throw an exception if the recipe is not found
            }
        }

        // Method to clear all recipes
        public static void ClearAllRecipes()
        {
            recipes.Clear(); // Clear all recipes from the dictionary
        }
    }
}
