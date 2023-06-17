using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookiesCookBook.Recipes.Ingredients
{
    public class Cardamom : Spice
    {
        public override int Id => 6;

        public override string Name => "Cardamom";
        public override string PreparationInstructions => base.PreparationInstructions;
        public override string ToString()
        {
            return $"{Id}. {Name}";
        }
    }
}
