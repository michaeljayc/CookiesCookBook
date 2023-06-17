using CookiesCookBook.Recipes.Ingredients;
using CookiesCookBook.Recipes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookiesCookBook.Interfaces
{
    public interface IUserInteraction
    {
        public void PrintExistingRecipes(IEnumerable<Recipe> recipes);
        public void PrintMessage(string message);
        public void Exit();
        public List<Ingredient> PromptToCreateRecipe();
    }
}
