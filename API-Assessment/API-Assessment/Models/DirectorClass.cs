using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace API_Assessment.Models
{
    public class DirectorClass
    {
        [Key]
        public string? DirectorId { get; set; }

        public string? DirectorName { get; set; }
        [Range(1,120)]
        public int? DirectorAge { get; set; }
        
        [Required]
        [EmailAddress]
        [StringLength(40)]
        public string? DirectorEmail { get; set; }
        [PasswordPropertyText]
        [Required]
        public string? DirectorPassword { get; set; }
        public string? DirectorExperience { get; set; }

        public ICollection<WebseriesClass>? WebseriesInstance { get; set; }

    }
}
