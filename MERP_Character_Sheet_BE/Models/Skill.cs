namespace MERP_Character_Sheet_BE.Models
{
    public class Skill
    {
        public long Id { get; set; }
        public int LevelBonus { get; set; }
    }

    public class StandaloneSkill: Skill
    {
        public int LevelUpSkillBonus { get; set; }
    }

    public class SkillTree
    {
        public long Id { get; set; }
        public int LevelUpSkillPoints { get; set; }
    }

    public class ArmorSkills : SkillTree
    {
        public Skill NoArmor { get; set; }
        public Skill Leather { get; set; }
        public Skill HardenedLeather { get; set; }
        public Skill ChainMail { get; set; }
        public Skill Plate { get; set; }
    }

    public class WeaponSkills : SkillTree
    {
        public Skill Edge { get; set; }
        public Skill Blunt { get; set; }
        public Skill TwoHanded { get; set; }
        public Skill Throw { get; set; }
        public Skill Aim { get; set; }
        public Skill DualWheilding { get; set; }
        public Skill Pole { get; set; }
    }

    public class ExteriorSkills : SkillTree
    {
        public Skill Climb { get; set; }
        public Skill Mount { get; set; }
        public Skill Swim { get; set; }
        public Skill Track { get; set; }
    }

    public class SurvivalSkills : SkillTree
    {
        public Skill Ambush { get; set; }
        public Skill Hide { get; set; }
        public Skill LockPick { get; set; }
        public Skill TrapDismantle { get; set; }
    }

    public class MagicSkills : SkillTree
    {
        public int NewMagicListChance { get; set; }
        public Skill ReadRunes { get; set; }
        public Skill UseObject { get; set; }
        public Skill AimedSpells { get; set; }
        public Skill BaseSpellBonus { get; set; }
    }

    public class GlobalSkills : SkillTree
    {
        public Skill Sight { get; set; }
        public StandaloneSkill Health { get; set; }
        public Skill Languages { get; set; }
    }

    public class ClassSkills
    {
        public long Id { get; set; }
        public ArmorSkills Armor { get; set; }
        public WeaponSkills Weapons { get; set; }
        public ExteriorSkills Exterior { get; set; }
        public SurvivalSkills Survival { get; set; }
        public MagicSkills Magic { get; set; }
        public GlobalSkills Global { get; set; }
    }
    //TODO: Add secondary skills here.
}
