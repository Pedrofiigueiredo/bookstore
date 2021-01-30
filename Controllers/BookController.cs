using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BooksApi.Models;
using BooksApi.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BooksApi.Controllers
{
  [ApiController]
  [Route("api/books")]
  public class BookController : ControllerBase
  {
    private readonly BookRepository _repository;
    public BookController(BookRepository repository)
    {
        _repository = repository;
    }

    [HttpGet("")]
    public ActionResult<List<Book>> Get() =>
      _repository.Get();

    [HttpGet("{id}", Name = "GetBook")]
    public ActionResult<Book> Get(string id)
    {
      var book = _repository.Get(id);

      if (book == null)
        return NotFound();
      
      return book;
    }

    [HttpPost("")]
    public ActionResult<Book> Create(Book book)
    {
      _repository.Create(book);

      return CreatedAtRoute("GetBook", new { id = book.Id.ToString() }, book);
    }

    [HttpPut("{id}")]
    public IActionResult Update(string id, Book bookIn)
    {
      var book = _repository.Get(id);

      if (book == null)
        return NotFound();
      
      _repository.Update(id, bookIn);
      return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(string id)
    {
      var book = _repository.Get(id);

      if (book == null)
        return NotFound();
      
      _repository.Remove(book);
      return NoContent();
    }
  }
}
