using CookiesCookBook.Recipe.Ingredients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookiesCookBook.Interfaces
{
    public interface IUserInteraction
    {
        public void PrintAvailableIngredients();
        public IEnumerable<Ingredient> AddNewIngredients();
        public void PrintMessage(string message);
        public void Exit();
    }
}
