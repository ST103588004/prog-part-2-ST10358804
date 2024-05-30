using System;
using System.Collections.Generic;
using System.Linq;

/*Author:Teddy Smith
 * Availability: (https://youtube.com/playlist?list=PL82C6-O4XrHfoN_Y4MwGvJz5BntiL0z0D&si=9IiBbWs4lsCl8hFU)
 * date of access:10 April
 */
public class Recipe
{
    public string Name { get; set; }
    public List<Ingredient> Ingredients { get; set; }
    public List<string> Steps { get; set; }

    public Recipe()
    {
        Ingredients = new List<Ingredient>();
        Steps = new List<string>();
    }

    public double CalculateTotalCalories()
    {
        return Ingredients.Sum(ingredient => ingredient.Calories * ingredient.Quantity);
    }
}
