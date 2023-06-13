using CookiesCookBook.Recipe.Ingredients;

var app = new CookieRecipeApp(new CookieRepository(), new UserConsoleInteraction());
app.Run();


public class CookieRecipeApp
{
    private readonly ICookieRepository _cookieRepository;
    private readonly IUserInteraction _userConsoleInteraction;
    public CookieRecipeApp(CookieRepository cookieRepository, UserConsoleInteraction userConsoleInteraction) 
    {
        _cookieRepository= cookieRepository;
        _userConsoleInteraction= userConsoleInteraction;
    }
    public void Run()
    {
        var savedRecipes = _cookieRepository.Read();
        _userConsoleInteraction.PrintAvailableIngredients();
        var newIngredients = _userConsoleInteraction.AddNewIngredients();
        if(newIngredients.Count() > 0)
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
    public string Read()
    {
        return "";
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

public interface ICookieRepository
{

    public void Write(IEnumerable<Ingredient> ingredients);
    public string Read();
}

public interface IUserInteraction
{
    public void PrintAvailableIngredients();
    public IEnumerable<Ingredient> AddNewIngredients();
    public void PrintMessage(string message);
    public void Exit();
}