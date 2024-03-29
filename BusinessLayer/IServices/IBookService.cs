using System.Collections.Generic;
using SharedLayer.DTOs;

namespace BusinessLayer.IServices
{
    public interface IBookService
    {
        IEnumerable<BookDto> GetBooks();
        BookDto GetBookById(Guid id);
        BookDto CreateBook(BookDto bookDto);
        BookDto UpdateBook(Guid id, BookDto bookDto);
        BookDto DeleteBook(Guid id);

        BookDto RateBook(Guid bookId, double rating);
        BookDto ReturnBook(Guid bookId);

        BookDto BorrowBook(Guid bookId, Guid borrowingUserId);
    }
}
