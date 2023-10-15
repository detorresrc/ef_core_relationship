namespace API.DTOs
{
    public class CharacterDto
    {
        public int Id { get; set; }
        public string Description { get; set; } = string.Empty;
        public string RpgClass { get; set; } = "Knight";
        public UserDto User { get; set; }
        public WeaponDto Weapon { get; set; }
        public List<SkillDto> Skills { get; set; }
    }
}