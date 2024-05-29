using Part2_ST10228343;
using RecipeAppPoe;
using Xunit;
using Assert = Xunit.Assert;

namespace CalorieTest
{
    public class RecipeCalorieTests
    {
        [Fact]
        public void ShouldWarnIfCaloriesExceedLimit()
        {
            // Arrange: Create a test recipe with ingredients whose total calories exceed the limit
            var highCalorieRecipe = new Recipe("High Calorie Recipe");
            highCalorieRecipe.AddIngredient("Sugar", 10, "grams", 50, "Sweets");
            highCalorieRecipe.AddIngredient("Butter", 20, "grams", 100, "Dairy");
            highCalorieRecipe.AddIngredient("Flour", 30, "grams", 50, "Grains");

            // Act: Check if the recipe exceeds the calorie limit
            bool exceedsLimit = highCalorieRecipe.ExceedsCalorieLimit();

            // Assert: The recipe should exceed the calorie limit
            Assert.True(exceedsLimit);
        }

        [Fact]
        public void ShouldNotWarnIfCaloriesDoNotExceedLimit()
        {
            // Arrange: Create a test recipe with ingredients whose total calories do not exceed the limit
            var lowCalorieRecipe = new Recipe("Low Calorie Recipe");
            lowCalorieRecipe.AddIngredient("Sugar", 5, "grams", 50, "Sweets");
            lowCalorieRecipe.AddIngredient("Butter", 10, "grams", 100, "Dairy");

            // Act: Check if the recipe exceeds the calorie limit
            bool exceedsLimit = lowCalorieRecipe.ExceedsCalorieLimit();

            // Assert: The recipe should not exceed the calorie limit
            Assert.False(exceedsLimit);
        }

        [Fact]
        public void ShouldWarnIfCaloriesExceedLimitAfterScaling()
        {
            // Arrange: Create a test recipe with ingredients
            var scalableRecipe = new Recipe("Scalable Recipe");
            scalableRecipe.AddIngredient("Sugar", 5, "grams", 50, "Sweets");
            scalableRecipe.AddIngredient("Butter", 10, "grams", 100, "Dairy");

            // Act: Scale the recipe and check if it exceeds the calorie limit
            scalableRecipe.ScaleRecipe(2); // Scaling by a factor of 2
            bool exceedsLimitAfterScaling = scalableRecipe.ExceedsCalorieLimit();

            // Assert: The scaled recipe should exceed the calorie limit
            Assert.True(exceedsLimitAfterScaling);
        }

        [Fact]
        public void ShouldNotWarnIfCaloriesDoNotExceedLimitAfterResetting()
        {
            // Arrange: Create a test recipe with ingredients
            var resettableRecipe = new Recipe("Resettable Recipe");
            resettableRecipe.AddIngredient("Sugar", 5, "grams", 50, "Sweets");
            resettableRecipe.AddIngredient("Butter", 10, "grams", 100, "Dairy");

            // Act: Scale the recipe, then reset the quantities, and check if it exceeds the calorie limit
            resettableRecipe.ScaleRecipe(2); // Scaling by a factor of 2
            resettableRecipe.ResetQuantities(); // Resetting to original quantities
            bool exceedsLimitAfterResetting = resettableRecipe.ExceedsCalorieLimit();

            // Assert: The reset recipe should not exceed the calorie limit
            Assert.False(exceedsLimitAfterResetting);
        }
    }
}
