using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*Author:Teddy Smith
 * Availability: (https://youtube.com/playlist?list=PL82C6-O4XrHfoN_Y4MwGvJz5BntiL0z0D&si=9IiBbWs4lsCl8hFU)
 * date of access:10 April
 */

namespace RecipeApp
{
    class Program
    {
        static void Main(string[] args)
        {
            RecipeManager recipeManager = new RecipeManager();
            recipeManager.OnHighCalorieRecipe += NotifyHighCalorieRecipe;

            while (true)
            {
                Console.WriteLine("\nWhat would you like to do?");
                Console.WriteLine("1. Enter a new recipe");
                Console.WriteLine("2. Display all recipes");
                Console.WriteLine("3. Display a specific recipe");
                Console.WriteLine("4. Clear all data");
                Console.WriteLine("5. Exit");

                int userOption = GetUserInput();
                try
                {
                    switch (userOption)
                    {
                        case 1:
                            Recipe recipe = CreateRecipe();
                            recipeManager.AddRecipe(recipe);
                            break;
                        case 2:
                            DisplayAllRecipes(recipeManager);
                            break;
                        case 3:
                            DisplaySpecificRecipe(recipeManager);
                            break;
                        case 4:
                            recipeManager.ClearAllData();
                            Console.WriteLine("All data cleared.");
                            break;
                        case 5:
                            Environment.Exit(0);
                            break;
                        default:
                            Console.WriteLine("Invalid option. Please try again.");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occurred: {ex.Message}");
                }
            }
        }

        static int GetUserInput()
        {
            int userOption;
            while (!int.TryParse(Console.ReadLine(), out userOption) || userOption < 1 || userOption > 5)
            {
                Console.WriteLine("Invalid input. Please enter a number between 1 and 5.");
            }
            return userOption;
        }

        static Recipe CreateRecipe()
        {
            Recipe recipe = new Recipe();

            Console.WriteLine("Enter the name of the recipe:");
            recipe.Name = Console.ReadLine();

            Console.WriteLine("Enter the number of ingredients:");
            int ingredientCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < ingredientCount; i++)
            {
                Ingredient ingredient = new Ingredient();

                Console.WriteLine($"Enter the name of ingredient {i + 1}:");
                ingredient.Name = Console.ReadLine();

                Console.WriteLine($"Enter the quantity of {ingredient.Name}:");
                ingredient.Quantity = double.Parse(Console.ReadLine());

                Console.WriteLine($"Enter the unit of measurement for {ingredient.Name}:");
                ingredient.Unit = Console.ReadLine();

                Console.WriteLine($"Enter the calories for {ingredient.Name}:");
                ingredient.Calories = double.Parse(Console.ReadLine());

                Console.WriteLine($"Enter the food group for {ingredient.Name}:");
                ingredient.FoodGroup = Console.ReadLine();

                recipe.Ingredients.Add(ingredient);
            }

            Console.WriteLine("Enter the number of steps:");
            int stepCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < stepCount; i++)
            {
                Console.WriteLine($"Enter step {i + 1}:");
                recipe.Steps.Add(Console.ReadLine());
            }

            Console.WriteLine("Recipe details entered successfully!");
            return recipe;
        }

        static void DisplayAllRecipes(RecipeManager recipeManager)
        {
            var recipes = recipeManager.GetSortedRecipes();
            Console.WriteLine("Recipes:");
            foreach (var recipe in recipes)
            {
                Console.WriteLine(recipe.Name);
            }
        }

        static void DisplaySpecificRecipe(RecipeManager recipeManager)
        {
            Console.WriteLine("Enter the name of the recipe to display:");
            string recipeName = Console.ReadLine();

            Recipe recipe = recipeManager.Recipes.FirstOrDefault(r => r.Name.Equals(recipeName, StringComparison.OrdinalIgnoreCase));
            if (recipe != null)
            {
                Console.WriteLine($"Recipe: {recipe.Name}");
                Console.WriteLine("Ingredients:");
                foreach (var ingredient in recipe.Ingredients)
                {
                    Console.WriteLine($"{ingredient.Quantity} {ingredient.Unit} of {ingredient.Name} ({ingredient.Calories} calories, {ingredient.FoodGroup})");
                }
                Console.WriteLine("Steps:");
                for (int i = 0; i < recipe.Steps.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {recipe.Steps[i]}");
                }
            }
            else
            {
                Console.WriteLine("Recipe not found.");
            }
        }

        static void NotifyHighCalorieRecipe(string recipeName, double totalCalories)
        {
            Console.WriteLine($"Warning: The recipe '{recipeName}' has a total of {totalCalories} calories, which exceeds the limit of 300 calories.");
        }
    }
}