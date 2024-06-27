using System;
using System.Collections.Generic;

namespace part3_ST10228343
{
    public delegate void RecipeExceedsCaloriesHandler();

    public static class RecipeHandler
    {
        private static Dictionary<string, Recipe<ItemsToBeUsed>> recipes = new Dictionary<string, Recipe<ItemsToBeUsed>>();

        public static event RecipeExceedsCaloriesHandler RecipeExceedsCaloriesEvent;

        public static void AddRecipe(Recipe<ItemsToBeUsed> recipe)
        {
            if (recipe == null)
                throw new ArgumentNullException(nameof(recipe));

            double totalCalories = recipe.TotalCalories(i => i.Calories);
            if (totalCalories > 300)
            {
                RecipeExceedsCaloriesEvent?.Invoke();
            }

            recipes.Add(recipe.Name, recipe);
        }

        public static void DeleteRecipe(string recipeName)
        {
            if (recipes.ContainsKey(recipeName))
            {
                recipes.Remove(recipeName);
            }
            else
            {
                throw new KeyNotFoundException($"Recipe '{recipeName}' not found.");
            }
        }

        public static List<string> GetRecipeNames()
        {
            return new List<string>(recipes.Keys);
        }

        public static Recipe<ItemsToBeUsed> GetRecipeByName(string recipeName)
        {
            if (recipes.TryGetValue(recipeName, out Recipe<ItemsToBeUsed> recipe))
            {
                return recipe;
            }
            else
            {
                throw new KeyNotFoundException($"Recipe '{recipeName}' not found.");
            }
        }

        public static void ClearAllRecipes()
        {
            recipes.Clear();
        }
    }
}
