using BusinessLayer.IServices;
using DataAccesLayer.Models;
using DataAccessLayer.IRepository;
using SharedLayer.DTOs;
using System.Collections.Generic;


namespace BusinessLayer.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;

        public BookService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public IEnumerable<BookDto> GetBooks()
        {
            var books = _bookRepository.GetBooks();
            return MapToBookDtoList(books);
        }

        public BookDto GetBookById(Guid id)
        {
            var book = _bookRepository.GetBookById(id);
            return MapToBookDto(book);
        }

        public BookDto CreateBook(BookDto bookDto)
        {
            var bookEntity = MapToBookEntity(bookDto);
            var createdBook = _bookRepository.AddBook(bookEntity);
            return MapToBookDto(createdBook);
        }

        public BookDto UpdateBook(Guid id, BookDto bookDto)
        {
            var existingBook = _bookRepository.GetBookById(id);

            if (existingBook == null)
            {
                return null; 
            }

            
            existingBook.Name = bookDto.Name;
            existingBook.Rating = bookDto.Rating;
            existingBook.Author = bookDto.Author;
            existingBook.Genre = bookDto.Genre;
            existingBook.IsBookAvailable = bookDto.IsBookAvailable;
            existingBook.Description = bookDto.Description;
            existingBook.LentByUserId = bookDto.LentByUserId;
            existingBook.CurrentlyBorrowedById = bookDto.CurrentlyBorrowedById;

            var updatedBook = _bookRepository.UpdateBook(existingBook);
            return MapToBookDto(updatedBook);
        }

        public BookDto DeleteBook(Guid id)
        {
            var deletedBook = _bookRepository.DeleteBook(id);
            return MapToBookDto(deletedBook);
        }

        // Helper method for mapping from Book entity to BookDto
        private BookDto MapToBookDto(BookModel book)
        {
            if (book == null)
            {
                return null;
            }

            return new BookDto
            {
                Id = book.Id,
                Name = book.Name,
                Rating = book.Rating,
                Author = book.Author,
                Genre = book.Genre,
                IsBookAvailable = book.IsBookAvailable,
                Description = book.Description,
                LentByUserId = book.LentByUserId,
                CurrentlyBorrowedById = book.CurrentlyBorrowedById
            };
        }

        
        private List<BookDto> MapToBookDtoList(IEnumerable<BookModel> books)
        {
            var bookDtoList = new List<BookDto>();
            foreach (var book in books)
            {
                var bookDto = MapToBookDto(book);
                bookDtoList.Add(bookDto);
            }
            return bookDtoList;
        }

        
        private BookModel MapToBookEntity(BookDto bookDto)
        {
            return new BookModel
            {
                Name = bookDto.Name,
                Rating = bookDto.Rating,
                Author = bookDto.Author,
                Genre = bookDto.Genre,
                IsBookAvailable = bookDto.IsBookAvailable,
                Description = bookDto.Description,
                LentByUserId = bookDto.LentByUserId,
                CurrentlyBorrowedById = bookDto.CurrentlyBorrowedById
            };
        }
        public BookDto BorrowBook(Guid bookId, Guid borrowingUserId)
        {
            var book = _bookRepository.GetBookById(bookId);

            if (book == null || !book.IsBookAvailable)
            {
                
                return null;
            }

            
            book.IsBookAvailable = false;
           
            book.CurrentlyBorrowedById = borrowingUserId.ToString();

            var updatedBook = _bookRepository.UpdateBook(book);

            return MapToBookDto(updatedBook);
        }
        public BookDto ReturnBook(Guid bookId)
        {
            var book = _bookRepository.GetBookById(bookId);

            if (book == null)
            {
                return null; 
            }

            book.CurrentlyBorrowedById = null;

            book.IsBookAvailable = true;

           
            var updatedBook=_bookRepository.UpdateBook(book);

            return MapToBookDto(updatedBook);

        }
        public BookDto RateBook(Guid bookId, double rating)
        {
            var book = _bookRepository.GetBookById(bookId);

            if (book == null)
            {
                return null; 
            }            
            book.Rating = rating;
            _bookRepository.UpdateBook(book);
            return MapToBookDto(book);
        }
    }
}
