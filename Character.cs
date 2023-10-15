namespace API
{
    public class Character
    {
        public int Id { get; set; }
        public string Description { get; set; } = string.Empty;
        public string RpgClass { get; set; } = "Knight";
        public User User { get; set; }
        public int UserId { get; set; }
        public Weapon? Weapon { get; set; }
        public int? WeaponId { get; set; }
        public List<Skill> Skills { get; set; } = new List<Skill>();
    }
}