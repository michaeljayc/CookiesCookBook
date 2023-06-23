using CookiesCookBook.Interfaces;

namespace CookiesCookBook.Repositories.StringsRepository
{
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
}
