using System.ComponentModel.DataAnnotations;

namespace praticerolebasedauthorization.Models
{
    public class User
    {
        [Key]
        public int userId { get; set; }
        public string? userName { get; set; }
        public string? userPassword { get; set; }
        public string? userEmail { get; set; }
        public string? userRole { get; set; }
    }
}
