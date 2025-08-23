using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_Assessment.Models
{
    public class SeasonsClass
    {
        [Key] 
        public String? SeasonId { get; set; }
        [StringLength(300)]
        public String? SeasonPhoto { get; set; }

        [ForeignKey("WebseriesId")]
        public String? WebseriesId { get; set; }
        public WebseriesClass? WebseriesInstance { get; set; }
        
    }
}
