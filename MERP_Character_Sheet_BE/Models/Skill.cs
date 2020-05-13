using System;

namespace MERP_Character_Sheet_BE.Models
{
    public class Skill : SkillDTO
    {
        public long Id { get; set; }
    }

    public class StandaloneSkill: Skill
    {
        public int LevelUpSkillBonus { get; set; }
    }

    public class SkillTree: SkillTreeDTO
    {
        public long Id { get; set; }
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

    ///////////////
    //DTO CLASSES//
    ///////////////
    public class SkillDTO
    {
        public int LevelBonus { get; set; }
    }

    public class StandaloneSkillDTO : SkillDTO
    {
        public int LevelUpSkillBonus { get; set; }

        public static explicit operator StandaloneSkillDTO(StandaloneSkill v)
        {
            return new StandaloneSkillDTO()
            {
                LevelBonus = v.LevelBonus,
                LevelUpSkillBonus = v.LevelUpSkillBonus
            };
        }
    }

    public class SkillTreeDTO
    {
        public int LevelUpSkillPoints { get; set; }
    }

    public class ArmorSkillsDTO : SkillTreeDTO
    {
        public SkillDTO NoArmor { get; set; }
        public SkillDTO Leather { get; set; }
        public SkillDTO HardenedLeather { get; set; }
        public SkillDTO ChainMail { get; set; }
        public SkillDTO Plate { get; set; }

        // parser (from regular class to DTO)
        public static explicit operator ArmorSkillsDTO(ArmorSkills v)
        {
            return new ArmorSkillsDTO
            {
                LevelUpSkillPoints = v.LevelUpSkillPoints,
                NoArmor = (SkillDTO)v.NoArmor,
                Leather = (SkillDTO)v.Leather,
                HardenedLeather = (SkillDTO)v.HardenedLeather,
                ChainMail = (SkillDTO)v.ChainMail,
                Plate = (SkillDTO)v.Plate,
            };
        }
    }

    public class WeaponSkillsDTO : SkillTreeDTO
    {
        public SkillDTO Edge { get; set; }
        public SkillDTO Blunt { get; set; }
        public SkillDTO TwoHanded { get; set; }
        public SkillDTO Throw { get; set; }
        public SkillDTO Aim { get; set; }
        public SkillDTO DualWheilding { get; set; }
        public SkillDTO Pole { get; set; }

        public static explicit operator WeaponSkillsDTO(WeaponSkills v)
        {
            return new WeaponSkillsDTO
            {
                LevelUpSkillPoints = v.LevelUpSkillPoints,
                Edge = (SkillDTO)v.Edge,
                Blunt = (SkillDTO)v.Blunt,
                TwoHanded = (SkillDTO)v.TwoHanded,
                Throw = (SkillDTO)v.Throw,
                Aim = (SkillDTO)v.Aim,
                DualWheilding = (SkillDTO)v.DualWheilding,
                Pole = (SkillDTO)v.Pole,
            };
        }
    }

    public class ExteriorSkillsDTO : SkillTreeDTO
    {
        public SkillDTO Climb { get; set; }
        public SkillDTO Mount { get; set; }
        public SkillDTO Swim { get; set; }
        public SkillDTO Track { get; set; }

        public static explicit operator ExteriorSkillsDTO(ExteriorSkills v)
        {
            return new ExteriorSkillsDTO
            {
                LevelUpSkillPoints = v.LevelUpSkillPoints,
                Climb = (SkillDTO)v.Climb,
                Mount = (SkillDTO)v.Mount,
                Swim = (SkillDTO)v.Swim,
                Track = (SkillDTO)v.Track,
            };
        }
    }

    public class SurvivalSkillsDTO : SkillTreeDTO
    {
        public SkillDTO Ambush { get; set; }
        public SkillDTO Hide { get; set; }
        public SkillDTO LockPick { get; set; }
        public SkillDTO TrapDismantle { get; set; }

        public static explicit operator SurvivalSkillsDTO(SurvivalSkills v)
        {
            return new SurvivalSkillsDTO
            {
                LevelUpSkillPoints = v.LevelUpSkillPoints,
                Ambush = (SkillDTO)v.Ambush,
                Hide = (SkillDTO)v.Hide,
                LockPick = (SkillDTO)v.LockPick,
                TrapDismantle = (SkillDTO)v.TrapDismantle,
            };
        }
    }

    public class MagicSkillsDTO : SkillTreeDTO
    {
        public int NewMagicListChance { get; set; }
        public SkillDTO ReadRunes { get; set; }
        public SkillDTO UseObject { get; set; }
        public SkillDTO AimedSpells { get; set; }
        public SkillDTO BaseSpellBonus { get; set; }

        public static explicit operator MagicSkillsDTO(MagicSkills v)
        {
            return new MagicSkillsDTO
            {
                LevelUpSkillPoints = v.LevelUpSkillPoints,
                NewMagicListChance = v.NewMagicListChance,
                ReadRunes = (SkillDTO)v.ReadRunes,
                UseObject = (SkillDTO)v.UseObject,
                AimedSpells = (SkillDTO)v.AimedSpells,
                BaseSpellBonus = (SkillDTO)v.BaseSpellBonus,
            };
        }
    }

    public class GlobalSkillsDTO : SkillTreeDTO
    {
        public SkillDTO Sight { get; set; }
        public StandaloneSkillDTO Health { get; set; }
        public SkillDTO Languages { get; set; }

        public static explicit operator GlobalSkillsDTO(GlobalSkills v)
        {
            return new GlobalSkillsDTO
            {
                LevelUpSkillPoints = v.LevelUpSkillPoints,
                Sight = (SkillDTO)v.Sight,
                Health = (StandaloneSkillDTO)v.Health,
                Languages = (SkillDTO)v.Languages,
            };
        }
    }

    public class ClassSkillsDTO
    {
        public ArmorSkillsDTO Armor { get; set; }
        public WeaponSkillsDTO Weapons { get; set; }
        public ExteriorSkillsDTO Exterior { get; set; }
        public SurvivalSkillsDTO Survival { get; set; }
        public MagicSkillsDTO Magic { get; set; }
        public GlobalSkillsDTO Global { get; set; }

         // parser (from regular class to DTO)
        public static explicit operator ClassSkillsDTO(ClassSkills v)
        {
            return new ClassSkillsDTO()
            {
                Armor = (ArmorSkillsDTO)v.Armor,
                Weapons = (WeaponSkillsDTO)v.Weapons,
                Exterior = (ExteriorSkillsDTO)v.Exterior,
                Survival= (SurvivalSkillsDTO)v.Survival,
                Magic = (MagicSkillsDTO)v.Magic,
                Global = (GlobalSkillsDTO)v.Global,
            };
        }
    }


}
