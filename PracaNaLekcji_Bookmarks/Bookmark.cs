using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracaNaLekcji_Bookmarks
{
    public class Bookmark
    {
        public int Id { get; set; }
        public int Page {  get; set; }
        public string? Description { get; set; }
        public int BookId { get; set; }
    }
}
