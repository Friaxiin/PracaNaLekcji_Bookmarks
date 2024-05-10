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
        public ObservableCollection<Bookmark> Bookmarks { get; private set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Description { get; set; }
        public DateTime PublishedOn { get; set; }

        public Book(string title, string author, string description, DateTime date)
        {
            Bookmarks = new ObservableCollection<Bookmark>();
            Title = title;
            Author = author;
            Description = description;
            PublishedOn = date;
        }

        public void AddBookmark(Bookmark bookmark)
        {
            Bookmarks.Add(bookmark);
            Database.SaveDataBaseToJsonFile();
        }
    }
}
