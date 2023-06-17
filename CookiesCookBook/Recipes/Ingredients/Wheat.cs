using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookiesCookBook.Recipes.Ingredients
{
    public class Wheat : Flour
    {
        public override int Id => 1;

        public override string Name => "Wheat flour";
        public override string PreparationInstructions => base.PreparationInstructions;
        public override string ToString()
        {
            return $"{Id}. {Name}";
        }
    }
}
