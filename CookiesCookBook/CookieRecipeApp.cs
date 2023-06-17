using CookiesCookBook.Interfaces;
using CookiesCookBook.Recipes;
using CookiesCookBook.Recipes.Ingredients;

namespace CookiesCookBook
{
    public class CookieRecipeApp
    {
        private readonly ICookieRepository _cookieRepository;
        private readonly IUserInteraction _userConsoleInteraction;
        public CookieRecipeApp(CookieRepository cookieRepository, UserConsoleInteraction userConsoleInteraction)
        {
            _cookieRepository = cookieRepository;
            _userConsoleInteraction = userConsoleInteraction;
        }
        public void Run(string filePath)
        {
            var allRecipes = _cookieRepository.Read(filePath);
            _userConsoleInteraction.PrintExistingRecipes(allRecipes);
            var selectedIngredients = _userConsoleInteraction.PromptToCreateRecipe();
        
            if (selectedIngredients.Count() > 0)
            {
                var recipe = new Recipe(selectedIngredients);
                allRecipes.Add(recipe);
                _cookieRepository.Write(filePath, allRecipes);
                _userConsoleInteraction.PrintMessage("Recipe Added:");
                _userConsoleInteraction.PrintMessage(recipe.ToString());
            }
            else
            {
                _userConsoleInteraction.PrintMessage("No ingredients have been saved. Recipe will not be saved.");
            }

            _userConsoleInteraction.Exit();
        }

    }

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
            List<string> recipesFromFile = _stringRepository.Read(filePath);
            var recipes = new List<Recipe>();

            if(recipesFromFile.Count > 0)
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
            foreach(string recipe in recipes)
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
                foreach(var ingredient in recipe.Ingredients)
                {
                    allIds.Add(ingredient.Id);
                }
                recipesAsStrings.Add(string.Join(" ", allIds));
                
            }
            _stringRepository.Write(filePath, recipesAsStrings);
        }
    }

    public class StringsTextualRepository : IStringRepository
    {
        public List<string> Read(string filePath)
        {
            var stringsFromFile = new List<string>();
            bool fileExists = File.Exists(filePath);
            if (fileExists)
            {
                var files = File.ReadAllLines(filePath);
                foreach (string file in files)
                {
                    stringsFromFile.Add(file);
                }

                return stringsFromFile;
            }

            return new List<string>();
        }

        public void Write(string filePath, List<string> allRecipes) => File.WriteAllLines(filePath, allRecipes);
    }

    public class UserConsoleInteraction : IUserInteraction
    {
        private readonly IngredientsRegister _ingredientsRegister;

        public UserConsoleInteraction(IngredientsRegister ingredientsRegister)
        {
            _ingredientsRegister = ingredientsRegister;
        }

        public void PrintExistingRecipes(IEnumerable<Recipe> recipes)
        {
            if(recipes is not null)
            {
                Console.WriteLine($"Existing recipes are: {Environment.NewLine}");
                int counter = 1;
                foreach(var recipe in recipes)
                {
                    Console.WriteLine($"*****{counter}*****");
                    Console.WriteLine(recipe.ToString());
                    Console.WriteLine();
                    counter++;
                }
            }
        }
        public List<Ingredient> PromptToCreateRecipe()
        {
            bool shallStop = false;
            List<Ingredient> selectedIngredients = new();
            Console.WriteLine("Create a new cookie recipe! Available ingredients are:");
            foreach(var ingredient in _ingredientsRegister.All)
            {
                Console.WriteLine(ingredient.ToString());
            }

            while(!shallStop)
            {
                Console.WriteLine("Add an ingredient by its ID, or type anything else if finished.");
                if((int.TryParse(Console.ReadLine(), out int input)) && input > 0 && input < 9)
                {
                    selectedIngredients.Add(_ingredientsRegister.GetById(input));
                }
                else
                {
                    shallStop = true;
                }
            }
            return selectedIngredients;

        }

        public void PrintMessage(string message)
        {
            Console.WriteLine(message);
        }
        public void Exit()
        {
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
        }
    }

    public class IngredientsRegister
    {
        public IEnumerable<Ingredient> All { get; } = new List<Ingredient>
        {
            new Wheat(),
            new Coconut(),
            new Butter(),
            new Chocolate(),
            new Sugar(),
            new Cardamom(),
            new Cinnamon(),
            new Cocoa(),
        };

        public Ingredient GetById(int id)
        {
            foreach(var ingredient in All)
            {
                if(ingredient.Id == id)
                {
                    return ingredient;
                }
            }

            return null;
        }

        public override string ToString()
        {
            List<string> ingredients = new();

            foreach(var item in All)
            {
                ingredients.Add(item.ToString());
            }

            return string.Join(Environment.NewLine, ingredients);
        }
    }
}
