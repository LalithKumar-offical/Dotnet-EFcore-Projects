using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace API_Assessment.Models
{
    public class WebseriesClass
    {
        [Key]
        public string? WebseriesId { get; set; }
        [Required]
        [StringLength(100)]
        public string? WebseriesTitle { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [JsonIgnore]
        public DateOnly WebseriesDate { get; set; }
        [Required]
        [StringLength(50)]
        public string? WebseriesType { get; set; }
        [Required]
        [StringLength(20)]
        public string? WebseriesAgerestrictions { get; set; }


        public ICollection<RatingClass>? RatingInstance { get; set; }
        public ICollection<SeasonsClass>? SeasonsInstance { get; set; }
        [Required]
        [ForeignKey("DirectorId")]
        public string? DirectorId { get; set; }
        public DirectorClass? DirectorInstance { get; set; }

    }
}
