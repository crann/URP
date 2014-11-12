using System.ComponentModel.DataAnnotations;

namespace URP.Domain.Entities
{
    public class Country
    {
        [Key]
        public int CountryId { get; set; }

        [Required]
        public string Name { get; set; }
        public string TelephoneCode { get; set; }
    }
}
