using BooksApi.Models;
using MongoDB.Driver;

namespace BooksApi.Data
{
  public class DataContext
  {
    public readonly IMongoCollection<Book> Book;
    public DataContext(IBookstoreDatabaseSettings settings)
    {
      var client = new MongoClient(settings.ConnectionString);
      var database = client.GetDatabase(settings.DatabaseName);
      
      Book = database.GetCollection<Book>(settings.BooksCollectionName);
    }
  }
}