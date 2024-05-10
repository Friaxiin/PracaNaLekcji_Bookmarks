using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracaNaLekcji_Bookmarks
{
    public class Bookmark
    {
        public int PageNumber { get; set; }
        public string Description { get; set; }

        public Bookmark(int pageNumber, string description)
        {
            PageNumber = pageNumber;
            Description = description;
        }
    }
}
