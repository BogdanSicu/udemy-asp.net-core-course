using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using my_books.Data.DTOs;
using my_books.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace my_books.Controllers
{
    [Route("api/authors")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        public AuthorService _authorService;

        public AuthorController(AuthorService authorService)
        {
            _authorService = authorService;
        }

        [HttpPost]
        public IActionResult AddAuthor([FromBody] AuthorDTO authorDTO)
        {
            _authorService.AddAuthor(authorDTO);
            return Ok();
        }

        [HttpGet]
        public IActionResult GetAllAuthorsWithBooks()
        {
            return Ok(_authorService.GetAllAuthorsWithBooks());
        }
    }
}
