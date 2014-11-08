using System.ComponentModel.DataAnnotations;

namespace URP.Domain.Entities
{
    public class Movie
    {
        [Key]
        public int MovieId { get; set; }

        [Required]
        public string Title { get; set; }
        public string TagLine { get; set; } 
        public int Length { get; set; } // In minutes
    }
}
