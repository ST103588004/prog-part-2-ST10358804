
Read Me Recipe app

# Recipe Application

Description
The Recipe Application allows users to manage and scale recipes. Users can enter details for multiple recipes, including ingredients, quantities, units, and preparation steps. The application also calculates the total calories of each recipe and notifies users when the total calories exceed 300.

 Installation Instructions
1. Clone the Repository:
   - Clone the repository from GitHub:
     ```bash
     git clone https://github.com/your-repo/recipe-app.git
     ```

2. Open the Project:
   - Open the solution file (`RecipeApp.sln`) in Visual Studio.

3. Restore NuGet Packages:
   - Go to `Tools > NuGet Package Manager > Manage NuGet Packages for Solution`.
   - Click `Restore` to install the necessary packages.

4. Build the Solution:
   -Press `Ctrl+Shift+B` to build the solution.




Usage Instructions
1. Run the Application:
   - Press `F5` or go to `Debug > Start Debugging`.

2. Enter a New Recipe:
   - Select option 1 to enter the number of ingredients, their names, quantities, units, and the steps for the recipe.

3. Display All Recipes:
   - Select option 2 to display a list of all recipes sorted alphabetically by name. Choose a recipe to view its details.

4. Scale the Recipe:
   - Select option 3 and enter a scaling factor (0.5, 2, or 3) to scale the ingredient quantities.

5. Reset Quantities:
   - Select option 4 to reset the ingredient quantities to their original values.

6. Clear All Data:
   - Select option 5 to clear all recipe data and start fresh.

7. Exit the Application:
   - Select option 6 to exit the program.

Class Structure
- Program: The main entry point for the application. Manages user interactions and command execution.
- RecipeManager: Manages multiple recipes, handles adding, scaling, and resetting recipes, and triggers high-calorie notifications.
- Recipe: Represents a recipe with ingredients and steps. Contains methods for calculating total calories and resetting quantities.
- Ingredient: Represents an ingredient with its name, quantity, unit, calories, and food group.

 Method Explanation
RecipeManager Class
- AddRecipe: Adds a new recipe to the list and triggers the high-calorie event if necessary.
- ScaleRecipe: Scales the ingredient quantities by a specified factor.
- ResetQuantities: Resets the ingredient quantities to their original values.
- DisplayAllRecipes: Displays all recipes in alphabetical order.

### Recipe Class
- CalculateTotalCalories: Calculates the total calories of all ingredients.
- SaveOriginalQuantities: Saves the original quantities of ingredients for resetting.
- ResetQuantities: Resets the ingredient quantities to their original values.

 Scaling Functionality
When scaling a recipe, the `ScaleRecipe` method in the `RecipeManager` class multiplies each ingredient's quantity by the provided scaling factor (0.5, 2, or 3). The quantities are adjusted in memory and reflected when the recipe is displayed.

## Program Execution
- Command-Line Interface: The program runs through a command-line interface. Follow the prompts to navigate through the menu options.
- IDE Execution: Run the application in Visual Studio by pressing `F5` or selecting `Start Debugging`.

## Error Handling
The application includes error handling to manage invalid inputs and exceptions:
- FormatException: Handles invalid number formats.
- OverflowException: Manages inputs that are too large or small.
- General Exception Handling**: Catches any other exceptions and provides informative error messages.

Unit Tests
Unit tests are implemented to ensure the application's functionality. Tests cover adding recipes, calculating total calories, scaling recipes, and high-calorie notifications.

Running Unit Tests
1. Open Test Explorer:
   - Go to `Test > Test Explorer`.

2. Run Tests:
   - Click `Run All` to execute all tests.

By following these instructions, you can set up, run, and test the Recipe Application. Enjoy managing your recipes efficiently!
