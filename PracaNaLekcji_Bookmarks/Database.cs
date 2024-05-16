using Microsoft.Data.Sqlite;
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
        private static readonly string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "books.db");
        /*
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
        */
        public static void CreateTables()
        {
            using (var db = new SqliteConnection($"Filename={dbPath}"))
            {
                db.Open();
                var CreateCommand = new SqliteCommand();
                CreateCommand.Connection = db;
                CreateCommand.CommandText = "CREATE TABLE IF NOT EXISTS Books (bookId INTEGER PRIMARY KEY AUTOINCREMENT, title TEXT, author TEXT, description TEXT)";
                CreateCommand.ExecuteReader().Close();
                CreateCommand.CommandText = "CREATE TABLE IF NOT EXISTS Bookmarks (bookmarkId INTEGER PRIMARY KEY AUTOINCREMENT, page_number INTEGER, description TEXT, book_id INTEGER)";
                CreateCommand.ExecuteReader();
            }
        }
        public static List<Book> ReadBooks()
        {
            var entries = new List<Book>();
            using (var db = new SqliteConnection($"Filename={dbPath}"))
            {
                db.Open();
                var selectCommand = new SqliteCommand();
                selectCommand.Connection = db;
                selectCommand.CommandText = "SELECT * FROM Books";
                SqliteDataReader reader = selectCommand.ExecuteReader();
                while (reader.Read())
                {
                    Book book = new Book(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3));
                    entries.Add(book);
                }
            }
            return entries;
        }
        public static void AddBook(Book book)
        {
            using (var db = new SqliteConnection($"Filename={dbPath}"))
            {
                db.Open();
                var insertCommand = new SqliteCommand();
                insertCommand.Connection = db;
                insertCommand.CommandText = "INSERT INTO Books (title, author, description) VALUES (@title, @author, @desc)";
                insertCommand.Parameters.AddWithValue("@title", book.Title);
                insertCommand.Parameters.AddWithValue("@author", book.Author);
                insertCommand.Parameters.AddWithValue("@desc", book.Description);
                insertCommand.ExecuteReader();
            }
        }
        public static void DeleteBook(Book book)
        {
            using (var db = new SqliteConnection($"Filename={dbPath}"))
            {
                db.Open();
                var deleteCommand = new SqliteCommand();
                deleteCommand.Connection = db;
                deleteCommand.CommandText = "DELETE FROM Books WHERE bookId=@id";
                deleteCommand.Parameters.AddWithValue("@id", book.Id);
                deleteCommand.ExecuteReader();
            }
        }
    }
}
