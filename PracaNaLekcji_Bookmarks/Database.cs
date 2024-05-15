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
        private static readonly string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\Books", "books.txt");
        private static readonly string dbPathB = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\Books", "bookmarks.txt");

        public static ObservableCollection<Book> Books;

        static Database()
        {
            if (Books == null)
            {
                //ReadDataBaseFromJsonFile();
                Books = ReadDataFromTxt();
            }
        }

        public static void AddBook(Book book)
        {
            Books.Add(book);
            //SaveDataBaseToJsonFile();
            SaveDataToTxt();
        }

        public static void RemoveBook(Book book)
        {
            Books.Remove(book);
            //SaveDataBaseToJsonFile();
            SaveDataToTxt();
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
        public static void SaveDataToTxt()
        {
            if (File.Exists(dbPath))
            {
                List<string> output = new List<string>();
                foreach (Book book in Books)
                {
                    string line = $"{book.Id};{book.Title};{book.Description};{book.Author}";
                    output.Add(line);
                }
                
                File.WriteAllLines(dbPath, output);
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
        public static ObservableCollection<Book> ReadDataFromTxt()
        {
            if(File.Exists(dbPath))
            {
                List<string> books = File.ReadAllLines(dbPath).ToList();
                ObservableCollection<Book> result = new ObservableCollection<Book>();

                foreach (string line in books)
                {
                    string[] entries = line.Split(';');
                    if (entries.Length > 0)
                    {
                        Book book = new Book(entries[1], entries[2], entries[3]);
                        result.Add(book);
                    }
                }
                return result;
            }
            else
            {
                return new ObservableCollection<Book>();
            }
        }
        public static void AddBookmark(Bookmark bookmark)
        {
            if (File.Exists(dbPath))
            {
                List<string> output = new List<string>();
                    string line = $"{bookmark.PageNumber};{bookmark.Description};{bookmark.BookId}";
                    output.Add(line);

                File.AppendAllLines(dbPathB, output);
            }
        }
        public static ObservableCollection<Bookmark> ReadBookmarksFromTxt(int bookId)
        {
            if (File.Exists(dbPath))
            {
                List<string> bookmarks = File.ReadAllLines(dbPathB).ToList();
                ObservableCollection<Bookmark> result = new ObservableCollection<Bookmark>();

                foreach (string line in bookmarks)
                {
                    string[] entries = line.Split(';');
                    if (entries.Length > 0 && int.Parse(entries[2]) == bookId)
                    {
                        Bookmark bookmark = new Bookmark(int.Parse(entries[0]), entries[1], int.Parse(entries[2]));
                        result.Add(bookmark);
                    }
                }
                return result;
            }
            else
            {
                return new ObservableCollection<Bookmark>();
            }
        }
    }
}
