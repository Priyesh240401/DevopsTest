using BusinessLayer.IServices;
using Microsoft.AspNetCore.Mvc;
using SharedLayer.DTOs;

namespace BookStore.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class BooksController : ControllerBase
	{
		private readonly IBookService _bookService;

		public BooksController(IBookService bookService)
		{
			_bookService = bookService;
		}

		[HttpGet]
		public IActionResult GetBooks()
		{
			var books = _bookService.GetBooks();
			return Ok(books);
		}

		[HttpGet("{id}")]
		public IActionResult GetBookById(Guid id)
		{
			var book = _bookService.GetBookById(id);

			if (book == null)
			{
				return NotFound();
			}

			return Ok(book);
		}

		[HttpPost]
		public IActionResult CreateBook([FromBody] AddBookDto bookDto)
		{
			Guid BookId = Guid.NewGuid();
			var bookDto1 = new BookDto
			{
				Id = BookId,
				Name = bookDto.Name,
				Rating = bookDto.Rating,
				Author = bookDto.Author,
				Genre = bookDto.Genre,
				Description = bookDto.Description,
				IsBookAvailable = bookDto.IsBookAvailable,
				LentByUserId = bookDto.LentByUserId,
				CurrentlyBorrowedById = bookDto.CurrentlyBorrowedById,

			};
			var createdBook = _bookService.CreateBook(bookDto1);

			return CreatedAtAction(nameof(GetBookById), new { id = createdBook.Id }, createdBook);
		}

		[HttpPut("{id}")]
		public IActionResult UpdateBook(Guid id, [FromBody] BookDto bookDto)
		{
			var updatedBook = _bookService.UpdateBook(id, bookDto);

			if (updatedBook == null)
			{
				return NotFound();
			}

			return Ok(updatedBook);
		}

		[HttpDelete("{id}")]
		public IActionResult DeleteBook(Guid id)
		{
			var deletedBook = _bookService.DeleteBook(id);

			if (deletedBook == null)
			{
				return NotFound();
			}

			return Ok(deletedBook);
		}
		// Add this method to your BooksController
		[HttpPut("borrow/{bookId}/{borrowingUserId}")]
		public IActionResult BorrowBook(Guid bookId, Guid borrowingUserId)
		{
			var updatedBook = _bookService.BorrowBook(bookId, borrowingUserId);

			if (updatedBook == null)
			{
				return NotFound();
			}

			return Ok(updatedBook);
		}
		[HttpPut("return/{bookId}")]
		public IActionResult ReturnBook(Guid bookId)
		{
			var updatedBook = _bookService.ReturnBook(bookId);

			if (updatedBook == null)
			{
				return NotFound();
			}

			return Ok(updatedBook);
		}
		[HttpPut("rate/{bookId}/{rating}")]
		public IActionResult RateBook(Guid bookId, double rating)
		{
			var updatedBook = _bookService.RateBook(bookId, rating);

			if (updatedBook == null)
			{
				return NotFound();
			}

			return Ok(updatedBook);
		}

	}

}
