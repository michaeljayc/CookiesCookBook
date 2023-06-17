using CookiesCookBook.Recipes.Ingredients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookiesCookBook.Recipes
{
    public class Recipe
    {
        public IEnumerable<Ingredient> Ingredients { get; }

        public Recipe(IEnumerable<Ingredient> ingredients)
        {
            Ingredients = ingredients;
        }

        public override string ToString()
        {
            string toString = "";
            foreach(var ingredient in Ingredients)
            {
                toString += $"{ingredient.Name}. {ingredient.PreparationInstructions}\n";
            }
            return toString;
        }
    }
}
