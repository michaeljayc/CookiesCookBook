using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookiesCookBook.Interfaces
{
    public interface IStringRepository
    {
        public List<string> ReadFromString(string filePath);
        public void WriteToString(string filePath, List<string> allRecipes);
    }
}
