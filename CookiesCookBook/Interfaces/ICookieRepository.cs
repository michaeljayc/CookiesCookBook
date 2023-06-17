using CookiesCookBook.Recipes.Ingredients;
using CookiesCookBook.Recipes;

namespace CookiesCookBook.Interfaces
{
    public interface ICookieRepository
    {
        public void Write(string filePath, List<Recipe> allRecipes);
        public List<Recipe> Read(string fileName);
    }
}
