namespace CookiesCookBook.Recipes.Ingredients
{
    public class Cocoa : Ingredient
    {
        public override int Id => 8;

        public override string Name => "Cocoa powder";
        public override string PreparationInstructions => base.PreparationInstructions;
        public override string ToString()
        {
            return $"{Id}. {Name}";
        }
    }
}
