using DataAccesLayer.Models;
using System.Collections.Generic;



namespace DataAccessLayer.IRepository
{
    public interface IBookRepository
    {
        IEnumerable<BookModel> GetBooks();
        BookModel GetBookById(Guid id);
        BookModel AddBook(BookModel book);
        BookModel UpdateBook(BookModel book);
        BookModel DeleteBook(Guid id);
    }
}
