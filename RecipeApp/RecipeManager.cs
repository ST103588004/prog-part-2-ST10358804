using System;
using System.Collections.Generic;
using System.Linq;

/*Author:Teddy Smith
 * Availability: (https://youtube.com/playlist?list=PL82C6-O4XrHfoN_Y4MwGvJz5BntiL0z0D&si=9IiBbWs4lsCl8hFU)
 * date of access:10 April
 */
public class RecipeManager
{
    public List<Recipe> Recipes { get; private set; }
    public delegate void HighCalorieHandler(string recipeName, double totalCalories);
    public event HighCalorieHandler OnHighCalorieRecipe;

    public RecipeManager()
    {
        Recipes = new List<Recipe>();
    }

    public void AddRecipe(Recipe recipe)
    {
        Recipes.Add(recipe);
        double totalCalories = recipe.CalculateTotalCalories();
        if (totalCalories > 300)
        {
            OnHighCalorieRecipe?.Invoke(recipe.Name, totalCalories);
        }
    }

    public List<Recipe> GetSortedRecipes()
    {
        return Recipes.OrderBy(r => r.Name).ToList();
    }

    public void ClearAllData()
    {
        Recipes.Clear();
    }
}
