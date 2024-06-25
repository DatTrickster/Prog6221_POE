using System;
using System.Collections.Generic;


    namespace part3_ST10228343
    {
        public delegate void RecipeExceedsCaloriesHandler();

        public static class RecipeHandler
        {
            private static Dictionary<string, Recipe<ItemsToBeUsed>> recipes = new Dictionary<string, Recipe<ItemsToBeUsed>>();

            public static event RecipeExceedsCaloriesHandler RecipeExceedsCaloriesEvent;

            public static void BeepSound(int times = 1)
            {
                for (int i = 0; i < times; i++)
                {
                    Console.Beep();
                }
            }

            public static void AddRecipe()
            {
                Console.WriteLine("\nEnter the name of the recipe:");
                string? recipeName = Console.ReadLine();

                if (recipeName != null)
                {
                    Recipe<ItemsToBeUsed> recipe = new Recipe<ItemsToBeUsed>(recipeName);

                    Console.WriteLine("Enter the number of ingredients:");
                    if (int.TryParse(Console.ReadLine(), out int ingredientCount))
                    {
                        for (int i = 0; i < ingredientCount; i++)
                        {
                            while (true)
                            {
                                Console.WriteLine($"\nIngredient {i + 1}:");
                                Console.WriteLine("Enter the name of the ingredient:");
                                string? ingredientName = Console.ReadLine();

                                if (ingredientName != null)
                                {
                                    if (recipe.Ingredients.ContainsKey(ingredientName))
                                    {
                                        Console.WriteLine($"An ingredient with the name '{ingredientName}' already exists. Please enter a different name.");
                                        continue;
                                    }

                                    double quantity;
                                    while (true)
                                    {
                                        Console.WriteLine($"Enter the quantity of {ingredientName} :");
                                        if (!double.TryParse(Console.ReadLine(), out quantity))
                                        {
                                            Console.ForegroundColor = ConsoleColor.Red;
                                            Console.WriteLine("Invalid input. Please enter a valid quantity.");
                                            Console.ResetColor();
                                            continue;
                                        }
                                        break;
                                    }

                                    Console.WriteLine("Enter the unit of measurement:");
                                    string? unitOfMeasurement = Console.ReadLine();

                                    Console.WriteLine("Enter a description:");
                                    string? description = Console.ReadLine();

                                    double calories;
                                    while (true)
                                    {
                                        Console.WriteLine("Enter the number of calories:");
                                        if (!double.TryParse(Console.ReadLine(), out calories))
                                        {
                                            Console.ForegroundColor = ConsoleColor.Red;
                                            Console.WriteLine("Invalid input. Please enter a valid number of calories.");
                                            Console.ResetColor();
                                            continue;
                                        }
                                        break;
                                    }

                                    Console.WriteLine("Enter the food group:");
                                    string? foodGroup = Console.ReadLine();

                                    ItemsToBeUsed ingredient = new ItemsToBeUsed
                                    {
                                        NameOfIngrediant = ingredientName,
                                        Quantity = quantity,
                                        UnitOfmeasurement = unitOfMeasurement,
                                        DescriptionOfItem = description,
                                        Calories = calories,
                                        FoodGroup = foodGroup
                                    };

                                    recipe.AddIngredient(ingredientName, ingredient);
                                    BeepSound();
                                    break;
                                }
                            }
                        }

                        double totalCalories = recipe.TotalCalories(i => i.Calories);
                        if (totalCalories > 300)
                        {
                            RecipeExceedsCaloriesEvent?.Invoke();
                        }

                        recipes.Add(recipeName, recipe);
                        Console.WriteLine("Recipe added successfully!");
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Invalid input. Please enter a valid number of ingredients.");
                        Console.ResetColor();
                    }
                }
            }
            public static void ViewRecipes()
        {
            if (recipes.Count == 0)
            {
                Console.WriteLine("No recipes found.");
                return;
            }

            Console.WriteLine("\nList of Recipes:");
            foreach (var recipe in recipes.Keys)
            {
                Console.WriteLine($"- {recipe}");
            }

            Console.WriteLine("\nEnter the name of the recipe to view details:");
            string? selectedRecipeName = Console.ReadLine();

            if (selectedRecipeName != null && recipes.TryGetValue(selectedRecipeName, out Recipe<ItemsToBeUsed>? selectedRecipe))
            {
                DisplayRecipeDetails(selectedRecipe);

                double totalCalories = selectedRecipe.TotalCalories(i => i.Calories);
                if (totalCalories > 300)
                {
                    BeepSound(3);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Warning: This recipe exceeds 300 calories.");
                    Console.ResetColor();

                    Console.WriteLine("Do you want to scale the recipe? (yes/no)");
                    string? scaleResponse = Console.ReadLine();

                    if (scaleResponse?.ToLower() == "yes")
                    {
                        Console.WriteLine("Enter the scaling factor (0.5, 2, 3):");
                        if (double.TryParse(Console.ReadLine(), out double scalingFactor))
                        {
                            ScaleRecipe(selectedRecipe, scalingFactor);
                            totalCalories = selectedRecipe.TotalCalories(i => i.Calories);

                            Console.WriteLine("\nScaled Recipe Details:");
                            DisplayRecipeDetails(selectedRecipe);

                            Console.WriteLine($"Total Calories after scaling: {totalCalories}");

                            if (totalCalories > 300)
                            {
                                BeepSound(3);
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Warning: Even after scaling, this recipe exceeds 300 calories.");
                                Console.ResetColor();

                                Console.WriteLine("Do you want to revert to the original quantities? (yes/no)");
                                string? revertResponse = Console.ReadLine();

                                if (revertResponse?.ToLower() == "yes")
                                {
                                    ScaleRecipe(selectedRecipe, 1 / scalingFactor);
                                    Console.WriteLine("Reverted to original quantities.");
                                    DisplayRecipeDetails(selectedRecipe);
                                }
                            }
                        }
                    }
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Recipe '{selectedRecipeName}' not found.");
                Console.ResetColor();
            }
        }

        public static void DeleteRecipe()
        {
            if (recipes.Count == 0)
            {
                Console.WriteLine("No recipes available to delete.");
                return;
            }

            DisplayRecipesTable();

            Console.WriteLine("\nEnter the name of the recipe to delete:");
            string? recipeName = Console.ReadLine();

            if (recipeName != null && recipes.Remove(recipeName))
            {
                Console.WriteLine($"Recipe '{recipeName}' deleted successfully.");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Recipe '{recipeName}' not found.");
                Console.ResetColor();
            }
        }

        public static void ClearAllRecipes()
        {
            recipes.Clear();
            Console.WriteLine("All recipes have been cleared.");
        }

        private static void DisplayRecipeDetails(Recipe<ItemsToBeUsed> recipe)
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine($"\nDetails of Recipe: {recipe.Name}");
            Console.WriteLine("+-------------------------+-------------------------+-------------------------+-------------------------+-------------------------+");
            Console.WriteLine("|      Name of Ingredient |             Quantity    |      Unit of Measurement|          Description     |          Calories       |");
            Console.WriteLine("+-------------------------+-------------------------+-------------------------+-------------------------+-------------------------+");

            foreach (var item in recipe.Ingredients.Values)
            {
                Console.WriteLine($"|{item.NameOfIngrediant?.PadRight(25)}|{item.Quantity.ToString().PadRight(25)}|{item.UnitOfmeasurement?.PadRight(25)}|{item.DescriptionOfItem?.PadRight(25)}|{item.Calories.ToString().PadRight(25)}|");
            }

            Console.WriteLine("+-------------------------+-------------------------+-------------------------+-------------------------+-------------------------+");
            Console.ResetColor();

            double totalCalories = recipe.TotalCalories(i => i.Calories);
            Console.WriteLine($"Total Calories: {totalCalories}");
        }

        private static void DisplayRecipesTable()
        {
            Console.WriteLine("+-------------------------+");
            Console.WriteLine("|        Recipe Name      |");
            Console.WriteLine("+-------------------------+");

            foreach (var recipe in recipes.Keys)
            {
                Console.WriteLine($"|{recipe.PadRight(25)}|");
            }

            Console.WriteLine("+-------------------------+");
        }

        private static void ScaleRecipe(Recipe<ItemsToBeUsed> recipe, double scalingFactor)
        {
            foreach (var ingredient in recipe.Ingredients.Values)
            {
                ingredient.Quantity *= scalingFactor;
                ingredient.Calories *= scalingFactor;
            }

            double totalCalories = recipe.TotalCalories(i => i.Calories);
            if (totalCalories > 300)
            {
                BeepSound(3);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Warning: After scaling, this recipe exceeds 300 calories.");
                Console.ResetColor();
            }
        }
    }
}
