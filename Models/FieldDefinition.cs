using System.ComponentModel.DataAnnotations;

namespace T4Challenge.Models
{
    public class FieldDefinition
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Type { get; set; }
    }
}
