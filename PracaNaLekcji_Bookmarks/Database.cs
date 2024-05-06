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
        static string BooksPath = App.DbBooksPath;
        static string BookmarksPath = App.DbBookmarksPath;

        public static void WriteBooksToFile(List<Book> books)
        {
            List<string> output = new List<string>();
            foreach (Book book in books) 
            {
                string line = $"{book.Id};{book.Title};{book.Description};{book.Author}";
                output.Add(line);
            }
            File.WriteAllLines(BooksPath, output);
        }
        public static List<Book> LoadBooks()
        {
            if(File.Exists(BooksPath))
            {
                List<string> result = File.ReadAllLines(BooksPath).ToList();
                List<Book> books = new List<Book>();

                foreach(var line in result)
                {
                    string[] entries = line.Split(';');

                    if (entries.Length > 1)
                    {
                        Book book = new Book(entries[1], entries[2], entries[3]);
                        books.Add(book);
                    }
                }
                return books;
            }
            else
            {
                return new List<Book>();
            }
        }
    }
}
