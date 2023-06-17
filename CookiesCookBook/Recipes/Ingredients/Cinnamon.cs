using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookiesCookBook.Recipes.Ingredients
{
    public class Cinnamon : Spice
    {
        public override int Id => 7;

        public override string Name => "Cinnamon";
        public override string PreparationInstructions => base.PreparationInstructions;
        public override string ToString()
        {
            return $"{Id}. {Name}";
        }
    }
}
