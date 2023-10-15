namespace API
{
    public class Skill
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Damage { get; set; } = 10;
        public List<Character> Characters { get; set; } = new List<Character>();
    }
}