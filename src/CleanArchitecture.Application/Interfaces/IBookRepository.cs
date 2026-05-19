using System.Collections.Generic;
using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Application.Interfaces
{
    public interface IBookRepository
    {
        IEnumerable<Book> GetAll();
        Book? GetById(Guid id);

        Book Add(Book entity);
        Book Update(Book entity);

        bool Delete(Book entity);
        bool Remove(Book entity);
    }
}