using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace RecipeApp.Tests
{
    [TestClass]
    public class RecipeManagerTests
    {
        [TestMethod]
        public void CalculateTotalCalories_ShouldReturnCorrectSum()
        {
            // Arrange
            var recipe = new Recipe();
            recipe.Ingredients.Add(new Ingredient { Name = "Sugar", Quantity = 1, Calories = 100 });
            recipe.Ingredients.Add(new Ingredient { Name = "Butter", Quantity = 2, Calories = 50 });

            // Act
            double totalCalories = recipe.CalculateTotalCalories();

            // Assert
            Assert.AreEqual(200, totalCalories);
        }

        [TestMethod]
        public void HighCalorieRecipeEvent_ShouldTriggerWhenCaloriesExceed300()
        {
            // Arrange
            var recipeManager = new RecipeManager();
            bool eventTriggered = false;
            recipeManager.OnHighCalorieRecipe += (name, calories) => eventTriggered = true;

            var recipe = new Recipe();
            recipe.Name = "High Calorie Recipe";
            recipe.Ingredients.Add(new Ingredient { Name = "Butter", Quantity = 4, Calories = 100 });

            // Act
            recipeManager.AddRecipe(recipe);

            // Assert
            Assert.IsTrue(eventTriggered, "The high calorie event should have been triggered.");
        }

        [TestMethod]
        public void HighCalorieRecipeEvent_ShouldNotTriggerWhenCaloriesAreUnder300()
        {
            // Arrange
            var recipeManager = new RecipeManager();
            bool eventTriggered = false;
            recipeManager.OnHighCalorieRecipe += (name, calories) => eventTriggered = true;

            var recipe = new Recipe();
            recipe.Name = "Low Calorie Recipe";
            recipe.Ingredients.Add(new Ingredient { Name = "Butter", Quantity = 2, Calories = 100 });

            // Act
            recipeManager.AddRecipe(recipe);

            // Assert
            Assert.IsFalse(eventTriggered, "The high calorie event should not have been triggered.");
        }
    }
}
