using CookiesCookBook.Interfaces;
using CookiesCookBook.Recipes.Ingredients;
using CookiesCookBook.Recipes;

namespace CookiesCookBook.Repositories.CookiesRepository
{
    public class CookieRepository : ICookieRepository
    {
        private readonly IStringRepository _stringRepository;
        private readonly IngredientsRegister _ingredientsRegister;

        public CookieRepository(IStringRepository stringRepository, IngredientsRegister ingredientsRegister)
        {
            _stringRepository = stringRepository;
            _ingredientsRegister = ingredientsRegister;
        }

        public List<Recipe> Read(string filePath)
        {
            List<string> recipesFromFile = _stringRepository.ReadFromString(filePath);
            var recipes = new List<Recipe>();

            if (recipesFromFile.Count > 0)
            {
                foreach (var recipeFromFile in recipesFromFile)
                {
                    var recipe = RecipeFromString(recipeFromFile);
                    recipes.Add(recipe);
                }
                return recipes;
            }

            return new List<Recipe>();
        }

        private Recipe RecipeFromString(string recipeFromFile)
        {
            var ingredients = new List<Ingredient>();
            string[] recipes = recipeFromFile.Split(' ');
            foreach (string recipe in recipes)
            {
                ingredients.Add(_ingredientsRegister.GetById(int.Parse(recipe)));
            }
            return new Recipe(ingredients);
        }

        public void Write(string filePath, List<Recipe> allRecipes)
        {
            var recipesAsStrings = new List<string>();
            foreach (var recipe in allRecipes)
            {
                var allIds = new List<int>();
                foreach (var ingredient in recipe.Ingredients)
                {
                    allIds.Add(ingredient.Id);
                }
                recipesAsStrings.Add(string.Join(" ", allIds));

            }
            _stringRepository.WriteToString(filePath, recipesAsStrings);
        }
    }
}
