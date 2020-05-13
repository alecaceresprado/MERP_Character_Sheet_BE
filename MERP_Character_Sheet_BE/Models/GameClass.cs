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

    ///////////////
    //DTO CLASSES//
    ///////////////

    public class GameClassDTO
    {
        public long Id { get; set; }
        public string ClassName { get; set; }
        public ClassSkillsDTO Skills { get; set; }

        // parser (from regular class to DTO)
        public static explicit operator GameClassDTO(GameClass v)
        {
            return new GameClassDTO()
            {
                Id = v.Id,
                ClassName = v.ClassName,
                Skills = (ClassSkillsDTO)v.Skills
            };
        }
    }
}
