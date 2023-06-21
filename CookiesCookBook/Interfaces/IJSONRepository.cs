using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookiesCookBook.Interfaces
{
    public interface IJSONRepository
    {
        public List<string> ReadFromJSON(string filePath);
        public void WriteToJSON(string filePath, List<string> allRecipes);
    }
}
