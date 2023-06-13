using CookiesCookBook.Interfaces;
using CookiesCookBook.Recipe.Ingredients;

namespace CookiesCookBook
{
    public class CookieRecipeApp
    {
        private readonly ICookieRepository _cookieRepository;
        private readonly IUserInteraction _userConsoleInteraction;
        private static string FileName => "recipes.txt";
        public CookieRecipeApp(CookieRepository cookieRepository, UserConsoleInteraction userConsoleInteraction)
        {
            _cookieRepository = cookieRepository;
            _userConsoleInteraction = userConsoleInteraction;
        }
        public void Run()
        {
            _cookieRepository.Read(FileName);
            //_userConsoleInteraction.PrintAvailableIngredients();
            var newIngredients = _userConsoleInteraction.AddNewIngredients();
            if (newIngredients.Count() > 0)
            {
                _cookieRepository.Write(newIngredients);
            }
            else
            {
                _userConsoleInteraction.PrintMessage("No ingredients have been saved. Recipe will not be saved.");
                _userConsoleInteraction.Exit();
            }
        }

    }

    public class CookieRepository : ICookieRepository
    {
        public void Read(string fileName)
        {
            string availableIngredients = "";
            int lineCounter = 0;
            StreamReader sr = new StreamReader(fileName);
            string line = sr.ReadLine();
            while (line != null)
            {
                lineCounter++;
                Console.WriteLine(line);
                line = sr.ReadLine();
            }
            sr.Close();
        }

        public void Write(IEnumerable<Ingredient> ingredients)
        {

        }
    }

    public class UserConsoleInteraction : IUserInteraction
    {
        public void PrintAvailableIngredients()
        {

        }

        public IEnumerable<Ingredient> AddNewIngredients()
        {
            var ingredients = new List<Ingredient>()
        { new Wheat(), new Sugar() };
            return ingredients;
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
}
