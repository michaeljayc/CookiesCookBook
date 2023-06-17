using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookiesCookBook.Recipes.Ingredients
{
    public class Sugar : Ingredient
    {
        public override int Id => 5;

        public override string Name => "Sugar";
        public override string PreparationInstructions => base.PreparationInstructions;
        public override string ToString()
        {
            return $"{Id}. {Name}";
        }
    }
}
