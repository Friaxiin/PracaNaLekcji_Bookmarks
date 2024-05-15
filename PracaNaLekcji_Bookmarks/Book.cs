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
        //public ObservableCollection<Bookmark> Bookmarks { get; private set; }
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Description { get; set; }
        public static int LastId { get; set; }

        public Book(string title, string author, string description)
        {
            //Bookmarks = new ObservableCollection<Bookmark>();
            Id = LastId;
            Title = title;
            Author = author;
            Description = description;
            LastId++;
        }
    }
}
