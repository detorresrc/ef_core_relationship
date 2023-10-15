using System.ComponentModel.DataAnnotations;

namespace API.DTOs
{
    public class SkillDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public int Damage { get; set; } = 10;
    }
}