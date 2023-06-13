using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookiesCookBook.Recipe.Ingredients
{
    public class Coconut : Flour
    {
        public override int Id => 2;

        public override string Name => "Coconut flour";
        public override string PreparationInstructions => base.PreparationInstructions;
    }
}
