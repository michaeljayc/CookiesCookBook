using CookiesCookBook;
using CookiesCookBook.UserInteraction;
using CookiesCookBook.Recipes.Ingredients;
using CookiesCookBook.Repositories.CookiesRepository;
using CookiesCookBook.Repositories.StringsRepository;

var app = new CookieRecipeApp(new CookieRepository(new StringsTextualRepository(), new IngredientsRegister()), 
        new UserConsoleInteraction(new IngredientsRegister()));
app.Run("recipes.txt");