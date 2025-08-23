using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace API_Assessment.Models
{
    public class RatingClass
    {
        [Key]
        public string? RatingId { get; set; }
        [Range(1,10)]
        public int? RatingNo { get; set; }
        [StringLength(200)]
        public string? RatingComment { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [JsonIgnore]
        public DateOnly RatingDate { get; set; }
        [ForeignKey("WebseriesId")]
        public string? WebseriesId { get; set; }
        public WebseriesClass? WebseriesInstance { get; set; }
        [ForeignKey("UserId")]
        public string? UserId { get; set; }
        public UserClass? UserInstance { get; set; }
    }
}
