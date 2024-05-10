using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracaNaLekcji_Bookmarks
{
    public static class Database
    {
        private static readonly string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\Books", "books.json");

        public static ObservableCollection<Book> Books { get; private set; }

        static Database()
        {
            if (Books == null)
            {
                ReadDataBaseFromJsonFile();
            }
        }

        public static void AddBook(Book book)
        {
            Books.Add(book);
            SaveDataBaseToJsonFile();
        }

        public static void RemoveBook(Book book)
        {
            Books.Remove(book);
            SaveDataBaseToJsonFile();
        }

        public static void SaveDataBaseToJsonFile()
        {
            if (File.Exists(dbPath))
            {
                string serializedDatabase = JsonConvert.SerializeObject(Books);
                File.Delete(dbPath);
                File.WriteAllText(dbPath, serializedDatabase);
            }
            else
            {
                Directory.CreateDirectory(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\Books"));

                string serializedDatabase = JsonConvert.SerializeObject(new List<Book>());
                File.WriteAllText(dbPath, serializedDatabase);
            }
        }

        private static void ReadDataBaseFromJsonFile()
        {
            if (File.Exists(dbPath))
            {
                string serializedDatabase = File.ReadAllText(dbPath);

                Books = JsonConvert.DeserializeObject<ObservableCollection<Book>>(serializedDatabase);
            }
            else
            {
                Directory.CreateDirectory(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\Books"));

                string serializedDatabase = JsonConvert.SerializeObject(new ObservableCollection<Book>());
                File.WriteAllText(dbPath, serializedDatabase);

                Books = new ObservableCollection<Book>();
            }
        }
    }
}
