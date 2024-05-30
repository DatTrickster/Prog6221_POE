using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestCalorieExceedsLimit()
        {
            // Arrange
            var ingredients = new List<Ingredient>
            {
                new Ingredient { Name = "Sugar", Quantity = 10, Unit = "grams", CaloriesPerUnit = 50, Category = "Sweets" },
                new Ingredient { Name = "Butter", Quantity = 20, Unit = "grams", CaloriesPerUnit = 100, Category = "Dairy" },
                new Ingredient { Name = "Flour", Quantity = 30, Unit = "grams", CaloriesPerUnit = 50, Category = "Grains" }
            };

            // Act
            int totalCalories = CalculateTotalCalories(ingredients);
            bool exceedsLimit = totalCalories > 200;

            // Assert
            Assert.IsTrue(exceedsLimit);
        }

        [TestMethod]
        public void TestCalorieDoesNotExceedLimit()
        {
            // Arrange
            var ingredients = new List<Ingredient>
            {
                new Ingredient { Name = "Sugar", Quantity = 2, Unit = "grams", CaloriesPerUnit = 50, Category = "Sweets" },
                new Ingredient { Name = "Butter", Quantity = 1, Unit = "grams", CaloriesPerUnit = 100, Category = "Dairy" }
            };

            // Act
            int totalCalories = CalculateTotalCalories(ingredients);
            bool doesNotExceedLimit = totalCalories <= 200;

            // Assert
            Assert.IsTrue(doesNotExceedLimit);
        }

        [TestMethod]
        public void TestCalorieLimitAfterScaling()
        {
            // Arrange
            var ingredients = new List<Ingredient>
            {
                new Ingredient { Name = "Sugar", Quantity = 5, Unit = "grams", CaloriesPerUnit = 50, Category = "Sweets" },
                new Ingredient { Name = "Butter", Quantity = 10, Unit = "grams", CaloriesPerUnit = 100, Category = "Dairy" }
            };

            // Act
            ScaleRecipe(ingredients, 2);
            int totalCalories = CalculateTotalCalories(ingredients);
            bool exceedsLimit = totalCalories > 200;

            // Assert
            Assert.IsTrue(exceedsLimit);
        }

        [TestMethod]
        public void TestCalorieLimitAfterResetting()
        {
            // Arrange
            var ingredients = new List<Ingredient>
            {
                new Ingredient { Name = "Sugar", Quantity = 5, Unit = "grams", CaloriesPerUnit = 50, Category = "Sweets" },
                new Ingredient { Name = "Butter", Quantity = 10, Unit = "grams", CaloriesPerUnit = 100, Category = "Dairy" }
            };

            // Act
            ScaleRecipe(ingredients, 2);
            ResetQuantities(ingredients);
            int totalCalories = CalculateTotalCalories(ingredients);
            bool doesNotExceedLimit = totalCalories <= 200;

            // Assert
            Assert.IsTrue(doesNotExceedLimit);
        }

        // Helper methods embedded within the test class
        private int CalculateTotalCalories(List<Ingredient> ingredients)
        {
            int totalCalories = 0;
            foreach (var ingredient in ingredients)
            {
                totalCalories += ingredient.Quantity * ingredient.CaloriesPerUnit;
            }
            return totalCalories;
        }

        private void ScaleRecipe(List<Ingredient> ingredients, int factor)
        {
            foreach (var ingredient in ingredients)
            {
                ingredient.Quantity *= factor;
            }
        }

        private void ResetQuantities(List<Ingredient> ingredients)
        {
            foreach (var ingredient in ingredients)
            {
                ingredient.Quantity = 0;
            }
        }

        [TestMethod]
        public void TestTotalCaloriesCount()
        {
            // Arrange
            var ingredients = new List<Ingredient>
    {
        new Ingredient { Name = "Sugar", Quantity = 5, Unit = "grams", CaloriesPerUnit = 50, Category = "Sweets" },
        new Ingredient { Name = "Butter", Quantity = 10, Unit = "grams", CaloriesPerUnit = 100, Category = "Dairy" }
    };

            // Act
            int totalCalories = CalculateTotalCalories(ingredients);

            // Assert
            Assert.AreEqual(5 * 50 + 10 * 100, totalCalories);
        }

        // Ingredient class embedded within the test class
        private class Ingredient
        {
            public string Name { get; set; }
            public int Quantity { get; set; }
            public string Unit { get; set; }
            public int CaloriesPerUnit { get; set; }
            public string Category { get; set; }
        }
    }
}
