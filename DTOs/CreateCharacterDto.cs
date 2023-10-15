using System.ComponentModel.DataAnnotations;

namespace API.DTOs
{
    public class CreateCharacterDto
    {
        [Required]
        public string Description { get; set; } = string.Empty;
        [Required]
        public string RpgClass { get; set; } = "Knight";
    }
}