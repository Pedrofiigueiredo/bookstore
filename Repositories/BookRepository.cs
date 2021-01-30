using System.Collections.Generic;
using BooksApi.Data;
using BooksApi.Models;
using MongoDB.Driver;

namespace BooksApi.Repositories
{
  public class BookRepository
  {
    private readonly DataContext _context;

    public BookRepository(DataContext context)
    {
      _context = context;
    }

    public List<Book> Get() =>
      _context.Book.Find(book => true).ToList();

    public Book Get(string id) =>
      _context.Book.Find<Book>(book => book.Id == id).FirstOrDefault();

    public Book Create(Book book)
    {
      _context.Book.InsertOne(book);
      return book;
    }

    public void Update(string id, Book bookIn) =>
      _context.Book.ReplaceOne(book => book.Id == id, bookIn);

    public void Remove(string id) =>
      _context.Book.DeleteOne(book => book.Id == id);

    public void Remove(Book bookIn) =>
      _context.Book.DeleteOne(book => book.Id == bookIn.Id);
  }
}