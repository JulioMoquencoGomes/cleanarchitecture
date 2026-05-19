using CleanArchitecture.Application.Interfaces;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Infrastructure.Data;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;

namespace CleanArchitecture.Infrastructure.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly AppDbContext _dbContext;

        public BookRepository(AppDbContext dbcontext)
        {
            _dbContext = dbcontext;
        }

        public IEnumerable<Book> GetAll() => _dbContext.Books.ToList();
        public Book? GetById(Guid id) =>  _dbContext.Books.FirstOrDefault(u => u.Id == id);
        
        public Book Add(Book entity)
        {
            _dbContext.Add(entity);
            return entity;
        }
        public Book Update(Book entity)
        {
            _dbContext.Update(entity);
            return entity;
        }
        public bool Delete(Book entity)
        {
            _dbContext.Remove(entity);
            return true;
        }
        public bool Remove(Book entity)
        {
            return this.Delete(entity);
        }
    }
}