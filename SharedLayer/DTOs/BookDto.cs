using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedLayer.DTOs
{
    public class BookDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public double Rating { get; set; }
        public string Author { get; set; }
        public string Genre { get; set; }
        public bool IsBookAvailable { get; set; }
        public string Description { get; set; }
        public string? LentByUserId { get; set; }
        public string? CurrentlyBorrowedById { get; set; }
    }
    public class AddBookDto
    {
       
        public string Name { get; set; }
        public double Rating { get; set; }
        public string Author { get; set; }
        public string Genre { get; set; }
        public bool IsBookAvailable { get; set; }
        public string Description { get; set; }
        public string? LentByUserId { get; set; }
        public string? CurrentlyBorrowedById { get; set; }
    }
}
