using CookiesCookBook.Interfaces;
using System.Text.Json;

namespace CookiesCookBook.Repositories.StringsRepository
{
    public class StringsJsonRepository : IJSONRepository
    {
        public List<string> ReadFromJSON(string filePath)
        {
            var jsonString = File.ReadAllText(filePath);
            var result = new List<string>();
            result = JsonSerializer.Deserialize<List<string>>(jsonString);
            return result;
        }

        public void WriteToJSON(string filePath, List<string> allRecipes)
        {
            string jsonString = JsonSerializer.Serialize(allRecipes);
            File.WriteAllText(filePath, jsonString);
        }
    }
}
