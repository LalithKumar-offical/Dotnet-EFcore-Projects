using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace API_Assessment.Models
{
    public class UserClass
    {
        [Key]
        public int UserId { get; set; }
        [StringLength(30)]
        public string? UserName { get; set; }
        [Required]
        [PasswordPropertyText]
        [StringLength(30)]
        public string? UserPassword { get; set; }
        [Required]
        [EmailAddress]
        [StringLength (40)]
        public string? UserEmail { get; set; }

        [Required]
        public bool? UserAdult { get; set; }
        public ICollection<RatingClass>? RatingInstance { get; set; }

        [StringLength(20)]
        public string? UserRole {get; set; }
    }
}
