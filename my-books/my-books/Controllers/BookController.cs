using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using my_books.Data.DTOs;
using my_books.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace my_books.Controllers
{
    [Route("api/books")]
    [ApiController]
    public class BookController : ControllerBase
    {

        public BooksService _booksService;

        public BookController(BooksService booksService)
        {
            _booksService = booksService;
        }

        [HttpPost]
        public IActionResult AddBookWithAuthors([FromBody] BookDTO bookDTO)
        {
            _booksService.AddBookWithAuthors(bookDTO);
            return Ok();
        }


        [HttpGet]
        public IActionResult GetBooks()
        {
            var bookList = _booksService.GetAllBooks();
            return bookList!=null ? Ok(bookList) : NotFound("No books found");
        }

        [HttpGet ("{bookId}")]
        public IActionResult GetBookById(int bookId)
        {
            var book = _booksService.GetOneBook(bookId);
            return book!=null? Ok(book) : NotFound("This ID doesn't exist");
        }

        [HttpPut("{bookId}")]
        public IActionResult UpdateBook([FromBody] BookDTO bookDTO, int bookId)
        {
            var _book = _booksService.UpdateBook(bookId, bookDTO);
            return _book != null ? Ok("Book with id " + bookId + " was updated") : NotFound("This book doesn't exist");
        }

        [HttpDelete("{bookId}")]
        public IActionResult DeleteBook(int bookId)
        {
            var _book = _booksService.DeleteBook(bookId);
            return _book != null ? Ok("Book with id " + bookId + " was deleted") : NotFound("This book doesn't exist");
        }
    }
}
