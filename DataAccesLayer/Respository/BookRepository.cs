using System.Collections.Generic;
using System.Linq;
using DataAccesLayer.Models;
using DataAccessLayer.IRepository;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Repository
{
    public class BookRepository : IBookRepository
    {
        private readonly DBContext _context;

        public BookRepository(DBContext context)
        {
            _context = context;
        }

        public IEnumerable<BookModel> GetBooks()
        {
            return _context.Books.ToList();
        }

        public BookModel GetBookById(Guid id)
        {
            return _context.Books.FirstOrDefault(b => b.Id == id);
        }

        public BookModel AddBook(BookModel book)
        {
            _context.Books.Add(book);
            _context.SaveChanges();
            return book;
        }

        public BookModel UpdateBook(BookModel book)
        {
            _context.Entry(book).State = EntityState.Modified;
            _context.SaveChanges();
            return book;
        }

        public BookModel DeleteBook(Guid id)
        {
            var book = _context.Books.Find(id);

            if (book == null)
            {
                return null;
            }

            _context.Books.Remove(book);
            _context.SaveChanges();
            return book;
        }
    }
}
