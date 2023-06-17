using CookiesCookBook;
using CookiesCookBook.Recipes.Ingredients;

var app = new CookieRecipeApp(new CookieRepository(new StringsTextualRepository(), new IngredientsRegister()), 
        new UserConsoleInteraction(new IngredientsRegister()));
app.Run("recipes.txt");