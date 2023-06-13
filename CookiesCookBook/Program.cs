using CookiesCookBook;
using CookiesCookBook.Recipe.Ingredients;

var app = new CookieRecipeApp(new CookieRepository(), new UserConsoleInteraction());
app.Run();