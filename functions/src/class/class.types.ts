export interface skill {
  levelBonus: number;
}

export interface classSkillTree {
  armor: {
    levelUpSkillPoints: number;
    noArmor: skill;
    leather: skill;
    hardenedLeather: skill;
    chainMail: skill;
    plate: skill;
  },
  weapons: {
    levelUpSkillPoints: number;
    edge: skill;
    blunt: skill;
    twoHands: skill;
    throw: skill;
    projectile: skill;
    dualWeapons: skill;
    pole: skill;
  },
  exterior: {
    levelUpSkillPoints: number;
    climb: skill;
    mount: skill;
    swim: skill;
    tracking: skill;
  },
  survival: {
    levelUpSkillPoints: number;
    ambush: skill;
    hide: skill;
    lockPick: skill;
    trapDismantle: skill;
  },
  magic: {
    levelUpSkillPoints: number;
    newMagicListChance: number;
    readRunes: skill;
    useObject: skill;
    aimedSpell: skill;
    baseSpellBonus: skill;
  },
  global: {
    sight: skill;
    health: {
      levelBonus: number;
      levelUpSkillPoints: number;
    },
    languages: {
      levelUpSkillPoints: number;
    },
  },
  secondary: {},
}

export interface ClassModel {
  className: string
  skills: classSkillTree,
}

export class Class implements ClassModel {
  className!: string;
  skills!: classSkillTree;

  constructor(classToCreate: ClassModel) {
    this.className = classToCreate.className;
    this.skills = classToCreate.skills;
  }
}