using Microsoft.EntityFrameworkCore;
using my_books.Data.DTOs;
using my_books.Data.Models;
using my_books.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace my_books.Data.Services
{
    public class BooksService
    {

        private AppDbContext _context;
        public BooksService(AppDbContext context)
        {
            _context = context;
        }

        public void AddBookWithAuthors(BookDTO bookDTO)
        {
            var _book = new Book()
            {
                Title = bookDTO.Title,
                Description = bookDTO.Description,
                isRead = bookDTO.isRead,
                DateRead = bookDTO.isRead ? bookDTO.DateRead.Value : null,
                Rating = bookDTO.isRead ? bookDTO.Rating.Value : null,
                Genre = bookDTO.Genre,
                CoverUrl = bookDTO.CoverUrl,
                DateAdded = DateTime.Now,
                PublisherId = bookDTO.PublisherId
            };

            _context.Books.Add(_book);
            _context.SaveChanges();

            foreach(var Id in bookDTO.AuthorsId)
            {
                var _book_author = new Book_Author()
                {
                    BookId = _book.Id,
                    AuthorId = Id
                };
                _context.Book_Authors.Add(_book_author);
                _context.SaveChanges();
            }
        }

        public List<BookWithNamesDTO> GetAllBooks()
        {
            var _books = _context.Books.Select(book => new BookWithNamesDTO()
            {
                Title = book.Title,
                Description = book.Description,
                isRead = book.isRead,
                DateRead = book.isRead ? book.DateRead.Value : null,
                Rating = book.isRead ? book.Rating.Value : null,
                Genre = book.Genre,
                CoverUrl = book.CoverUrl,
                PublisherName = book.Publisher.Name,
                AuthorsNames = book.Book_Authors.Select(n => n.Author.FullName).ToList()

            }).ToList();

            return _books;
        }

        public Book GetOneBook(int bookId)
        {
            return _context.Books.FirstOrDefault(x => x.Id == bookId);
        }

        public Book UpdateBook(int bookID, BookDTO bookDTO)
        {
            var _book = _context.Books.FirstOrDefault(x => x.Id == bookID);
            if(_book != null)
            {
                _book.Title = bookDTO.Title;
                _book.Description = bookDTO.Description;
                _book.isRead = bookDTO.isRead;
                _book.DateRead = bookDTO.isRead ? bookDTO.DateRead.Value : null;
                _book.Rating = bookDTO.isRead ? bookDTO.Rating.Value : null;
                _book.Genre = bookDTO.Genre;
                _book.CoverUrl = bookDTO.CoverUrl;

                _context.SaveChanges();
            }
            return _book;
        }

        public Book DeleteBook(int bookID)
        {
            var _book = _context.Books.FirstOrDefault(x => x.Id == bookID);
            if(_book != null)
            {
                _context.Remove(_book);
                _context.SaveChanges();
            }
            return _book;
        }
    }
}
