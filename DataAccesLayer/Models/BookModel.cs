using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccesLayer.Models
{
	public class BookModel
	{
		public Guid Id { get; set; }
		public string Name { get; set; }
		public double Rating { get; set; }
		public string Author { get; set; }
		public string Genre { get; set; }
		public bool IsBookAvailable { get; set; }
		public string Description { get; set; }

		// Nullable, as a book may not be lent or borrowed
		public string? LentByUserId { get; set; }
		public string? CurrentlyBorrowedById { get; set; }

		// Navigation properties

		[ForeignKey("LentByUserId")]
		public UserModel LentByUser { get; set; }

		[ForeignKey("CurrentlyBorrowedById")]
		public UserModel CurrentlyBorrowedByUser { get; set; }
	}
}
