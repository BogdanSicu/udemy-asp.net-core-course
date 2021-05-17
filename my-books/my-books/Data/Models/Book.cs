using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace my_books.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool isRead { get; set; }

        //? este pt atribute optionale
        public DateTime? DateRead { get; set; }
        public int? Rating { get; set; }
        public string Genre { get; set; }
        public string Author { get; set; }
        public string CoverUrl{ get; set; }
        public DateTime DateAdded { get; set; }
    }
}
