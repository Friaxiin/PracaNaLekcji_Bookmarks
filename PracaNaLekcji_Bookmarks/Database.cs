using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracaNaLekcji_Bookmarks
{
    public static class Database
    {
        private static readonly string PathBooks = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Books.txt");
        private static readonly string PathBookmarks = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Bookmarks.txt");
    }
}
