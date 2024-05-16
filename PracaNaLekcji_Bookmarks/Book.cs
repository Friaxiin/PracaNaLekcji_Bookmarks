using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracaNaLekcji_Bookmarks
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Description { get; set; }
        //public DateTime PublishedOn { get; set; }
        
        public Book(int id, string title, string author, string description)
        {
            Id = id;
            Title = title;
            Author = author;
            Description = description;
        }
        public Book(string title, string author, string description)
        {
            Title = title;
            Author = author;
            Description = description;
        }
        /*
        public void AddBookmark(Bookmark bookmark)
        {
            Bookmarks.Add(bookmark);
            Database.SaveDataBaseToJsonFile();
        }
        */
    }
}
