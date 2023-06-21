using CookiesCookBook.Interfaces;
using CookiesCookBook.Recipes.Ingredients;
using CookiesCookBook.Recipes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookiesCookBook.UserInteraction
{
    public class UserConsoleInteraction : IUserInteraction
    {
        private readonly IngredientsRegister _ingredientsRegister;

        public UserConsoleInteraction(IngredientsRegister ingredientsRegister)
        {
            _ingredientsRegister = ingredientsRegister;
        }

        public void PrintExistingRecipes(IEnumerable<Recipe> recipes)
        {
            if (recipes is not null)
            {
                Console.WriteLine($"Existing recipes are: {Environment.NewLine}");
                int counter = 1;
                foreach (var recipe in recipes)
                {
                    Console.WriteLine($"*****{counter}*****");
                    Console.WriteLine(recipe.ToString());
                    Console.WriteLine();
                    counter++;
                }
            }
        }
        public List<Ingredient> PromptToCreateRecipe()
        {
            bool shallStop = false;
            List<Ingredient> selectedIngredients = new();
            Console.WriteLine("Create a new cookie recipe! Available ingredients are:");
            foreach (var ingredient in _ingredientsRegister.All)
            {
                Console.WriteLine(ingredient.ToString());
            }

            while (!shallStop)
            {
                Console.WriteLine("Add an ingredient by its ID, or type anything else if finished.");
                if ((int.TryParse(Console.ReadLine(), out int input)) && input > 0 && input < 9)
                {
                    selectedIngredients.Add(_ingredientsRegister.GetById(input));
                }
                else
                {
                    shallStop = true;
                }
            }
            return selectedIngredients;

        }

        public void PrintMessage(string message)
        {
            Console.WriteLine(message);
        }
        public void Exit()
        {
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
        }
    }
}
