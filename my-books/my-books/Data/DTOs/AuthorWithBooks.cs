using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace my_books.Data.DTOs
{
    public class AuthorWithBooks
    {
        public string FullName { get; set; }
        public List<string> BookTitles { get; set; }
    }
}
