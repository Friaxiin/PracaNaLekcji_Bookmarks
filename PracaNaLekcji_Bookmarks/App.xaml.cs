using System.Configuration;
using System.Data;
using System.IO;
using System.Windows;

namespace PracaNaLekcji_Bookmarks
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static string DbBooksPath
        {
            get
            {
                string PathBooks = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Books.txt");
                return PathBooks;
            }
        }
        public static string DbBookmarksPath
        {
            get
            {
                string PathBookmarks = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Bookmarks.txt");
                return PathBookmarks;
            }
        }
    }

}
