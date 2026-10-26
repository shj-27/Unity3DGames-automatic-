
/// <summary>
/// 기타 공용 열거형
/// 슬롯, 개체 유형, 업그레이드 등
/// </summary>
namespace EtcEnumList
{
    /// <summary>
    /// 슬롯 상태
    /// </summary>
    public enum SlotState
    {
        Empty,
        Available,
        Full
    }

    /// <summary>
    /// 게임 내 객체 타입
    /// </summary>
    public enum EntityType
    {
        Character,
        Item,
        NPC,
        Enemy
    }

    /// <summary>
    /// 범용 업그레이드 단계
    /// </summary>
    public enum UpgradeTierSlot
    {
        Tier1 = 1,
        Tier2 = 2,
        Tier3 = 3,
        Tier4 = 4,
        Tier5 = 5
    }

    /// <summary>
    /// 고급 업그레이드 단계
    /// </summary>
    public enum UpgradeTierAdvanced
    {
        Tier1 = 1,
        Tier2 = 2,
        Tier3 = 3,
        Tier4 = 4,
        Tier5 = 5,
        Tier6 = 6,
        Tier7 = 7,
        Tier8 = 8,
        Tier9 = 9,
        Tier10 = 10
    }
}

/// <summary>
/// 캐릭터 관련 열거형
/// </summary>
namespace CharacterEnumList
{
    public enum GenderType
    {
        None = 0,
        Male,
        Female
    }

    public enum CharacterBodyType
    {
        None = 0,
        Biped = 1,
        Quadruped = 2,
        NoLegs = 3
    }

    public enum CharacterStateType
    {
        None = 0,
        Idle = 1,
        Move = 2,
        Attack = 3,
        Gather = 4
    }

    public enum Grade
    {
        None = 0,
        Normal = 1,
        Rare = 2,
        Unique = 3,
        Epic = 4,
        Legend = 5
    }

    public enum Talent
    {
        None = 0,
        Genius = 1,
        Normal = 2,
        Poor = 3
    }

    public enum JobType
    {
        None = 0,
        Warrior = 1,
        Mage = 2,
        Swordsman = 3,
        Archer = 4,
        Rogue = 5
    }

    public enum PartType
    {
        Head,
        Body,
        Leg
    }
}

/// <summary>
/// 캐릭터 행동 관련 열거형
/// </summary>
namespace CharacterAction
{
    public enum CharacterActionType
    {
        None = 0,
        Idle = 1,
        Move = 2,
        Attack = 3,
        Gather = 4,
        Craft = 5,
        Rest = 6,
        Talk = 7,
        Hobby = 8
    }

    public enum MoveType
    {
        None = 0,
        Walk = 1,
        Run = 2
    }

    public enum AttackType
    {
        None = 0,
        Basic = 1,
        Skill = 2
    }

    public enum GatherType
    {
        None = 0,
        Wood = 1,
        Ore = 2,
        Plant = 3
    }

    public enum CraftType
    {
        None = 0,
        Create = 1,
        Process = 2
    }

    public enum RestType
    {
        None = 0,
        Sit = 1,
        Lie = 2
    }

    public enum TalkType
    {
        None = 0,
        Conversation = 1,
        Greeting = 2,
        Persuade = 3
    }

    public enum HobbyType
    {
        None = 0,
        Reading = 1,
        Study = 2,
        Fishing = 3,
        PlayingMusic = 4
    }
}

/// <summary>
/// 아이템 관련 열거형
/// </summary>
namespace ItemEnumList
{
    public enum ItemOwnerState
    {
        None = 0,
        Ground = 1,
        Drop = 2,
        Storage = 3
    }

    public enum ItemType
    {
        None = 0,
        Consumable = 1,
        Equipment = 2,
        Material = 3,
        Etc = 4,
        Event = 5
    }

    public enum EtcType
    {
        None = 0,
        Material = 1,
        Junk = 2,
        Quest = 3
    }

    public enum MaterialType
    {
        None = 0,
        Ore = 1,
        Lumber = 2,
        Fiber = 3,
        Food = 4
    }
}

/// <summary>
/// 장비 관련 열거형
/// </summary>
namespace EquipmentList
{
    public enum EquipmentType
    {
        None = 0,
        Weapon = 1,
        Armor = 2,
        Shoes = 3,
        Accessory = 4
    }

    public enum EquipmentStat
    {
        None = 0,
        PhysicalDamage = 1,
        MagicDamage = 2,
        PhysicalDefense = 3,
        MagicResistance = 4,
        MoveSpeed = 5
    }
}

/// <summary>
/// 능력치 관련 열거형
/// </summary>
namespace StatList
{
    public enum BasicStatList
    {
        None,
        HP,
        MP,
        STR,
        AGI,
        INTEL,
        WIS,
        CHA
    }
}

/// <summary>
/// 상태 이상 관련 열거형
/// </summary>
namespace StatusEffectList
{
    public enum StatusEffect
    {
        None = 0,
        Poison = 1,
        Confusion = 2,
        Paralysis = 3,
        Silence = 4,
        Burn = 5
    }
}

/// <summary>
/// 관계 관련 열거형
/// </summary>
namespace RelationshipType
{
    public enum Family
    {
        None = 0,
        Mother,
        Father,
        Son,
        Daughter
    }

    public enum Relatives
    {
        None = 0,
        Grandfather,
        Grandmother,
        Uncle,
        MaternalUncle,
        Aunt,
        PaternalAunt
    }

    public enum SocialRelationships
    {
        None = 0,
        Lover,
        Friend,
        ChildhoodFriend
    }

    public enum GrudgeRelationships
    {
        None = 0,
        Benefactor,
        Nemesis
    }

    public enum PartyRoles
    {
        None = 0,
        Leader,
        Tank,
        Scout,
        Support,
        DPS
    }

    public enum RaceType
    {
        None = 0,
        Human = 1,
        Orc = 2,
        Elf = 3,
        Dwarf = 4,
        Goblin = 5,
        DarkElf = 6,
        WoodElf = 7,
        HighElf = 8,
        Ogre = 9,
        Halfling = 10,
        Gnome = 11,
        Beastkin = 12,
        Lizardfolk = 13,
        Troll = 14,
        Minotaur = 15,
        Catfolk = 16,
        Werewolf = 17,
        Giant = 18,
        Dragonkin = 19,
        Fairy = 20,
        Demon = 21,
        Vampire = 22,
        Undead = 23,
        Spirit = 24,
        Merfolk = 25,
        Angel = 26,
        Wyvern = 27,
        Centaur = 28,
        Harpy = 29,
        Satyr = 30,
        Ent = 31,
        Dragon = 32
    }
}
