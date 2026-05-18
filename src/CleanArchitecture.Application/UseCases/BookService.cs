using CleanArchitecture.Application.Interfaces;
using CleanArchitecture.Domain.Entities;
using System.Collections.Generic;

namespace CleanArchitecture.Application.UseCases
{
    public class BookService
    {
        private readonly IBookRepository _bookRepository;

        public BookService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public IEnumerable<Book> GetBooks() => _bookRepository.GetAll();

        public Book GetBook(Guid id) => _bookRepository.GetById(id);
    }
}