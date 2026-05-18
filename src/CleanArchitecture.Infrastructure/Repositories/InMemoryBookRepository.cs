using CleanArchitecture.Application.Interfaces;
using CleanArchitecture.Domain.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;

namespace CleanArchitecture.Infrastructure.Repositories
{
    public class InMemoryBookRepository : IBookRepository
    {
        private readonly List<Book> _books = new()
        {
            new Book(id: Guid.NewGuid(), name: "Don Quixote", author: "Miguel de Cervantes"),
            new Book(id: Guid.NewGuid(), name: "1984", author: "George Orwell"),
            new Book(id: Guid.NewGuid(), name: "Pride and Prejudice", author: "Jane Austen"),
            new Book(id: Guid.NewGuid(), name: "Harry Potter", author: "J.K. Rowling"),
        };

        public IEnumerable<Book> GetAll() => _books;

        public Book? GetById(Guid id) => _books.FirstOrDefault(u => u.Id == id);
    }
}