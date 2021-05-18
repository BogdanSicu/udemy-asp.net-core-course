using my_books.Data;
using my_books.Data.DTOs;
using my_books.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace my_books.Services
{
    public class AuthorService
    {
        private AppDbContext _context;
        public AuthorService(AppDbContext context)
        {
            _context = context;
        }

        public void AddAuthor(AuthorDTO authorDTO)
        {
            var _author = new Author()
            {
                FullName = authorDTO.FullName
            };

            _context.Authors.Add(_author);
            _context.SaveChanges();
        }

        public List<AuthorWithBooks> GetAllAuthorsWithBooks()
        {
            return _context.Authors.Select(x => new AuthorWithBooks()
            {
                FullName = x.FullName,
                BookTitles = x.Book_Authors.Select(n => n.Book.Title).ToList()
            }).ToList();
        }
    }
}
