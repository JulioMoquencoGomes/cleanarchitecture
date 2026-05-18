using System.Net;
using CleanArchitecture.Domain.ValueObjects;

namespace CleanArchitecture.Domain.Entities;

public class Book: TrackableEntity
{
    public Guid Id { get; set; }
    public String Name { get; set; }
    public String Author { get; set; }
    
    public Book(Guid id, String name, String author)
    {
        this.Id = id;
        this.Name = name;
        this.Author = author;
    }
}
