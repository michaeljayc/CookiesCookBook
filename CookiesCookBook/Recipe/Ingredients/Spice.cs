using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookiesCookBook.Recipe.Ingredients
{
    public abstract class Spice : Ingredient
    {
        public override string PreparationInstructions => $"Take half a teaspoon. {base.PreparationInstructions}";
    }
}
