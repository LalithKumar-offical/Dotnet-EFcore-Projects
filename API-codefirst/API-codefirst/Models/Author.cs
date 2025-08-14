using System.ComponentModel.DataAnnotations;

namespace API_codefirst.Models
{
    public class Author
    {
        [Key]
        public int authorId {  get; set; }
        public string? authorName { get; set; }

        public decimal? phoneNumber { get; set; }

        public virtual ICollection<Book>? Books { get; set; }    

    }
}
