using CookiesCookBook.Recipe.Ingredients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookiesCookBook.Interfaces
{
    public interface ICookieRepository
    {
        public void Write(IEnumerable<Ingredient> ingredients);
        public void Read(string fileName);
    }
}
