using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccesLayer.Models
{
	public class UserModel
	{
		public string Id { get; set; }
		public string Name { get; set; }
		public string Username { get; set; }
		public string Password { get; set; }
		public int TokensAvailable { get; set; }

		// Navigation properties
		public ICollection<BookModel> BooksBorrowed { get; set; }
		public ICollection<BookModel> BooksLent { get; set; }
	}

}
