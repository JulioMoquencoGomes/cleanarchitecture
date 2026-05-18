using Microsoft.AspNetCore.Mvc;
using CleanArchitecture.Application.UseCases;
using CleanArchitecture.Domain.Entities;
using System.Collections.Generic;

namespace CleanArchitecture.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookController : ControllerBase
    {
        private readonly BookService _bookService;

        public BookController(BookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet]
        public IEnumerable<Book> Get() => _bookService.GetBooks();

        [HttpGet("{id}")]
        public ActionResult<Book> Get(Guid id)
        {
            var book = _bookService.GetBook(id);
            if (book == null)
                return NotFound();
            return book;
        }
    }
}