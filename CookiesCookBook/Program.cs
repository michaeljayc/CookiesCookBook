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

    }


}

public class CookieRepository : ICookieRepository
{

}

public class UserConsoleInteraction : IUserInteraction
{

}

public interface ICookieRepository
{

}

public interface IUserInteraction
{
    
}