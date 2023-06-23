using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookiesCookBook.Recipes.Ingredients
{
    public class IngredientsRegister
    {
        public IEnumerable<Ingredient> All { get; } = new List<Ingredient>
        {
            new Wheat(),
            new Coconut(),
            new Butter(),
            new Chocolate(),
            new Sugar(),
            new Cardamom(),
            new Cinnamon(),
            new Cocoa(),
        };

        public Ingredient GetById(int id)
        {
            foreach (var ingredient in All)
            {
                if (ingredient.Id == id)
                {
                    return ingredient;
                }
            }

            return null;
        }

        public override string ToString()
        {
            List<string> ingredients = new();

            foreach (var item in All)
            {
                ingredients.Add(item.ToString());
            }

            return string.Join(Environment.NewLine, ingredients);
        }
    }
}
