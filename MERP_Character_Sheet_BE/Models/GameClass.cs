using System;
namespace MERP_Character_Sheet_BE.Models
{
    public class GameClass
    {
        public long Id { get; set; }
        public string ClassName { get; set; }
        public ClassSkills Skills { get; set; }
        // TODO: Add secondary skills
        public GameClass()
        {
        }
    }
}
