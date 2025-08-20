using System.ComponentModel.DataAnnotations;

namespace praticerolebasedauthorization.Models
{
    public class Webseries
    {
        [Key]
        public int? webseriesId { get; set; }
        public string? webseriesName { get; set; }
       
        public decimal? WebseriesRating { get; set; }
        

    }
}
