using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using my_books.Data.Services;
using my_books.Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace my_books.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        //- injecting the book services
        public BooksServices _booksServices;

        public BooksController(BooksServices booksServices)
        {
            _booksServices = booksServices;
        }

        //-> Post New Book Data to servi
        [HttpPost("add-book-with-authors")]
        public IActionResult AddBook([FromBody] BookVM book)
        {
            _booksServices.AddBookWithAuthors(book);
            return Ok();
        }

        //-> Get All Books 
        [HttpGet("get-all-books")]
        public IActionResult GetAllBooks()
        {
            var allBooks = _booksServices.GetAllBooks();
            return Ok(allBooks);
        }

        //-> Get Book By ID
        [HttpGet("get-book-by-id/{id}")]
        public IActionResult GetBookById(int id)
        {
            var book = _booksServices.GetBookById(id);
            return Ok(book);
        }

        //-> Get Book Author By Id using Relations many yo many 
        [HttpGet("get-book-author-by-id/{id}")]
        public IActionResult GetBookAuthorById(int id)
        {
            var book = _booksServices.GetBookAuthorById(id);
            return Ok(book);
        }


        //-> update Book By Id
        [HttpPut("updateBookById/{id}")]
        public IActionResult UpdateBookById(int id, [FromBody] BookVM book)
        {
            var updateBook = _booksServices.UpdateBookById(id, book);
            return Ok(updateBook);
        }


        //-> Delete Book By Id 
        [HttpDelete("DeleteBookById /{id}")]
        public IActionResult DeleteBookById( int id )
        {
            _booksServices.DeleteBookById(id);
            return Ok();
        }
    }
}
