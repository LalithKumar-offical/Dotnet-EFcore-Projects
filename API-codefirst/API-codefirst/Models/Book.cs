using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_codefirst.Models
{
    public class Book
    {
        [Key]
        public int bookId { get; set; }
        public string? bookTitle { get; set; }

        public int? authorId { get; set; }
        [ForeignKey(nameof(authorId))]
        public virtual Author? Author { get; set; }
    }
}
