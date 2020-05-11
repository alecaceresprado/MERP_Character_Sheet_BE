namespace MERP_Character_Sheet_BE.Models
{
    public class CharacterDetails
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string NickName { get; set; }
        public Race Race { get; set; }
        public string Height { get; set; }
        public string Weight { get; set; }
        public string HairColor { get; set; }
        public string EyesColor { get; set; }
        public string PhysicalSpecial { get; set; }
        public string ClassName { get; set; }
        public GameClass Class { get; set; }
        public long Experience { get; set; }
        public int Level { get; set; }
    }
}
