using System.ComponentModel.DataAnnotations;

namespace API.DTOs
{
    public class AddSkillDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public int Damage { get; set; } = 10;
        [Required]
        public int CharacterId { get; set; }
    }
}