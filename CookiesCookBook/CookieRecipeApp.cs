using CookiesCookBook.Interfaces;
using CookiesCookBook.Recipes;
using CookiesCookBook.Repositories.CookiesRepository;
using CookiesCookBook.UserInteraction;

namespace CookiesCookBook
{
    public class CookieRecipeApp
    {
        private readonly ICookieRepository _cookieRepository;
        private readonly IUserInteraction _userConsoleInteraction;
        public CookieRecipeApp(CookieRepository cookieRepository, UserConsoleInteraction userConsoleInteraction)
        {
            _cookieRepository = cookieRepository;
            _userConsoleInteraction = userConsoleInteraction;
        }
        public void Run(string filePath)
        {
            var allRecipes = _cookieRepository.Read(filePath);
            _userConsoleInteraction.PrintExistingRecipes(allRecipes);
            var selectedIngredients = _userConsoleInteraction.PromptToCreateRecipe();
        
            if (selectedIngredients.Count() > 0)
            {
                var recipe = new Recipe(selectedIngredients);
                allRecipes.Add(recipe);
                _cookieRepository.Write(filePath, allRecipes);
                _userConsoleInteraction.PrintMessage("Recipe Added:");
                _userConsoleInteraction.PrintMessage(recipe.ToString());
            }
            else
            {
                _userConsoleInteraction.PrintMessage("No ingredients have been saved. Recipe will not be saved.");
            }

            _userConsoleInteraction.Exit();
        }

    }
}
