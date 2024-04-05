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
        public ObservableCollection<Bookmark> Bookmarks { get; set; }
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
        public DateTime PublishedOn { get; set; }

        public Book(string title, string description, string author, DateTime publishedOn)
        {
            Bookmarks = new ObservableCollection<Bookmark>();
            Title = title;
            Description = description;
            Author = author;
            PublishedOn = publishedOn;
        }

        public void AddBookmark(Bookmark bookmark)
        {
            Bookmarks.Add(bookmark);
            //Save to file txt
        }
        public void RemoveBookmark(Bookmark bookmark)
        {
            Bookmarks.Remove(bookmark);
            //Save to file txt
        }
    }
}
