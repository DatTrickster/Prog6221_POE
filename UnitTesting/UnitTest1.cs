using Part2_ST10228343;
using Xunit;

namespace CalorieTest
{
    public class RecipeCalorieTest
    {
        [Fact]
        public void TestCalorieExceedsLimit()
        {
            // Arrange
            var recipe = new Recipe();
            recipe.AddIngredient("Sugar", 100, "grams", 5, "Sweets");
            recipe.AddIngredient("Butter", 200, "grams", 3, "Dairy");
            recipe.AddIngredient("Flour", 300, "grams", 2, "Grains");

            // Act
            int totalCalories = 0;
            foreach (var ingredient in recipe.GetIngredients())
            {
                totalCalories += ingredient.Quantity * ingredient.CaloriesPerUnit;
            }
            bool exceedsLimit = totalCalories > 200;

            // Assert
            Xunit.Assert.True(exceedsLimit);
        }

        // Other test methods can be similarly modified
    }

    // Recipe and Ingredient classes remain unchanged
}
