using my_books.Data;
using my_books.Data.DTOs;
using my_books.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace my_books.Services
{
    public class PublisherService
    {
        private AppDbContext _context;
        public PublisherService(AppDbContext context)
        {
            _context = context;
        }

        public void AddPublisher(PublisherDTO publisherDTO)
        {
            var _publisher = new Publisher()
            {
                Name = publisherDTO.Name
            };

            _context.Publishers.Add(_publisher);
            _context.SaveChanges();
        }

        public List<PublisherWithBooksAndAuthorsDTO> GetAllPublishers()
        {
            return _context.Publishers.Select(x => new PublisherWithBooksAndAuthorsDTO()
            {
                Name = x.Name,
                BookAuthors = x.Books.Select(n => new BookAuthorDTO()
                {
                    BookName = n.Title,
                    BookAuthors = n.Book_Authors.Select(author => author.Author.FullName).ToList()
                }).ToList()
            }).ToList();
        }

        public void DeletePublisherById(int publisherId)
        {
            var _publisher = _context.Publishers.FirstOrDefault(n => n.Id == publisherId);
            if(_publisher != null)
            {
                _context.Publishers.Remove(_publisher);
                _context.SaveChanges();
            }
        }
    }
}
