using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 슬롯 상태 (인벤토리 / 주점 / 자리 시스템 등 공용)
/// </summary>
public enum SlotState
{
    Empty,      // 비어 있음 (아무것도 없음)
    Available,  // 사용 가능 (자리 있음 / 공간 있음)
    Full        // 가득 참 (더 이상 추가 불가)
}

/// <summary>
/// 게임 내 모든 객체의 기본 타입 분류
/// </summary>
public enum EntityType
{
    Character,  // 플레이어/유닛 캐릭터
    Item,       // 아이템
    NPC,        // 일반 NPC
    Enemy       // 적
}

/// <summary>
/// 캐릭터의 신체 및 이동 형태
/// 행동 구현 시 이동 방식이나 필요한 행동을 구분하는 데 사용
/// </summary>
public enum CharacterBodyType
{
    None = 0,          // 형태 없음

    Biped = 1,         // 2족 보행
    Quadruped = 2,     // 4족 보행
    NoLegs = 3         // 다리 없음
}

/// <summary>
/// 캐릭터 행동 상태 (AI / 애니메이션 / 상태머신용)
/// </summary>
public enum CharacterStateType
{
    None = 0,   // 상태 없음
    Idle = 1,   // 대기 / 정지
    Move = 2,   // 이동 중
    Attack = 3, // 공격 중
    Gather = 4  // 수집 / 채집 / 작업 상태
}

/// <summary>
/// 캐릭터 등급 (성장 / 드랍 / 가챠 확률용)
/// </summary>
public enum Grade
{
    None = 0,   // 없음 (초기값)
    Normal = 1, // 일반
    Rare = 2,   // 희귀
    Unique = 3, // 고급
    Epic = 4,   // 영웅급
    Legend = 5  // 전설
}

/// <summary>
/// 재능 (성장 속도 / 경험치 효율)
/// </summary>
public enum Talent
{
    None = 0,   // 성장 불가 / 특수 상태
    Genius = 1, // 성장 매우 빠름 (경험치 요구량 낮음)
    Normal = 2, // 기본 성장 속도
    Poor = 3    // 성장 느림 (경험치 요구량 높음)
}

/// <summary>
/// 직업 타입 (캐릭터 역할 / 스탯 기반 분류)
/// </summary>
public enum JobType
{
    None = 0,        // 미지정
    Warrior = 1,     // 전사 (근접 / 탱커)
    Mage = 2,        // 마법사 (마법 공격)
    Swordsman = 3,   // 검사 (균형형 근접)
    Archer = 4,      // 궁수 (원거리)
    Rogue = 5        // 도적 (기동성 / 암살)
}

/// <summary>
/// 범용 업그레이드 단계 (가방 / 건물 / 생산 등 시스템용)
/// - 단순 확장 레벨 구조
/// - 1~5 단계로 제한된 시스템에 사용
/// </summary>
public enum UpgradeTierSlot
{
    Tier1 = 1, // 초기 단계
    Tier2 = 2, // 약간 확장
    Tier3 = 3, // 중간 확장
    Tier4 = 4, // 고급 확장
    Tier5 = 5  // 최종 확장
}

/// <summary>
/// 고급 업그레이드 단계 (장비 / 캐릭터 스킬 전용)
/// - 세분화된 성장 구조
/// - 1~10 단계로 구성
/// - 장비 강화 / 스킬 성장 시스템에 사용
/// </summary>
public enum UpgradeTierAdvanced
{
    Tier1 = 1,  // 초기
    Tier2 = 2,
    Tier3 = 3,
    Tier4 = 4,
    Tier5 = 5,
    Tier6 = 6,
    Tier7 = 7,
    Tier8 = 8,
    Tier9 = 9,
    Tier10 = 10 // 최종 단계
}
/// <summary>
/// - 캐릭터 파츠
/// 
/// </summary>
public enum PartType
{
    Head,
    Body,
    Leg
}

/// <summary>
/// 아이템의 현재 소유 상태
/// 아이템의 종류가 아니라 현재 아이템이 어떤 상태로 존재하는지를 나타냄
/// </summary>
public enum ItemOwnerState
{
    None = 0,       // 상태 없음 / 초기 상태
    Ground = 1,     // 주인 없음 / 길바닥에 존재
    Drop = 2,       // 드랍된 아이템
    Storage = 3     // 창고에 보관된 아이템
}

/// <summary>
/// 아이템의 종류
/// 아이템이 어떤 용도로 사용되는지를 나타냄
/// </summary>
public enum ItemType
{
    None = 0,       // 종류 없음 / 초기 상태
    Consumable = 1, // 소모품
    Equipment = 2,  // 장비
    Material = 3,   // 재료
    Etc = 4,        // 기타
    Event = 5       // 이벤트 아이템
}

/// <summary>
/// 캐릭터 능력치 목록
/// 아이템 효과 및 캐릭터 능력치 변경 등에 사용
/// </summary>
public class StatList
{
    /// <summary>
    /// 캐릭터의 기본 능력치
    /// CharacterData의 능력치와 대응
    /// </summary>
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
/// 캐릭터 상태 이상 목록
/// 소모품 효과 및 상태 이상 적용/회복 등에 사용
/// </summary>
public class StatusEffectList
{
    /// <summary>
    /// 캐릭터에게 적용되는 상태 이상
    /// </summary>
    public enum StatusEffect
    {
        None = 0,      // 상태 이상 없음
        Poison = 1,    // 중독
        Confusion = 2, // 혼란
        Paralysis = 3, // 마비
        Silence = 4,   // 침묵 (마법 관련)
        Burn = 5       // 화상
    }
}

/// <summary>
/// 장비 종류 목록
/// 장비 아이템이 어떤 부위에 해당하는지를 나타냄
/// </summary>
public class EquipmentList
{
    /// <summary>
    /// 장비 부위
    /// </summary>
    public enum EquipmentType
    {
        None = 0,       // 장비 종류 없음
        Weapon = 1,     // 무기
        Armor = 2,      // 아머
        Shoes = 3,      // 신발
        Accessory = 4   // 악세사리
    }
}

/// <summary>
/// 장비 고유 능력치 목록
/// </summary>
public class EquipmentStatList
{
    /// <summary>
    /// 장비에 적용되는 고유 능력치
    /// </summary>
    public enum EquipmentStat
    {
        None = 0,

        // 공격 관련
        PhysicalDamage = 1,   // 물리 공격력
        MagicDamage = 2,      // 마법 공격력

        // 방어 관련
        PhysicalDefense = 3,  // 물리 방어력
        MagicResistance = 4,  // 마법 저항력

        // 이동 관련
        MoveSpeed = 5         // 이동 속도
    }
}

/// <summary>
/// 기타 아이템의 세부 종류
/// </summary>
public class EtcItemList
{
    /// <summary>
    /// 기타 아이템 종류
    /// </summary>
    public enum EtcType
    {
        None = 0,       // 종류 없음
        Material = 1,   // 재료용
        Junk = 2,       // 잡템용
        Quest = 3       // 퀘스트용
    }
}

/// <summary>
/// 재료 아이템의 종류
/// </summary>
public class MaterialItemList
{
    public enum MaterialType
    {
        None = 0,
        Ore = 1,       // 광석
        Lumber = 2,    // 목재
        Fiber = 3,     // 섬유
        Food = 4       // 식욕용
    }
}

/// <summary>
/// 캐릭터의 큰 행동 종류
/// </summary>
public enum CharacterActionType
{
    None = 0,

    /// <summary>
    /// 특별한 행동을 하지 않고 대기하는 상태
    /// </summary>
    Idle = 1,

    /// <summary>
    /// 목적지를 향해 이동하는 행동
    /// </summary>
    Move = 2,

    /// <summary>
    /// 대상에게 공격을 수행하는 행동
    /// </summary>
    Attack = 3,

    /// <summary>
    /// 자원이나 대상을 채집하는 행동
    /// </summary>
    Gather = 4,

    /// <summary>
    /// 재료를 이용하여 아이템 등을 제작하는 행동
    /// </summary>
    Craft = 5,

    /// <summary>
    /// 피로 등을 회복하기 위해 휴식하는 행동
    /// </summary>
    Rest = 6,

    /// <summary>
    /// 다른 캐릭터와 상호작용하는 행동
    /// </summary>
    Talk = 7,

    /// <summary>
    /// 캐릭터가 취미나 개인적인 활동을 하는 행동
    /// </summary>
    Hobby = 8
}

/// <summary>
/// 캐릭터 행동 관련 Enum 모음
/// 
/// 실제 행동은 각각의 Action 클래스에서 담당하고,
/// 여기서는 해당 행동에서 사용되는 세부 종류만 정의한다.
/// </summary>
public class CharacterAction
{
    /// <summary>
    /// 이동 행동의 세부 종류
    /// </summary>
    public enum MoveType
    {
        None = 0,

        // 일반적인 속도로 이동
        Walk = 1,

        // 빠른 속도로 이동
        Run = 2
    }

    /// <summary>
    /// 공격 행동의 세부 종류
    /// </summary>
    public enum AttackType
    {
        None = 0,

        // 기본적인 일반 공격
        Basic = 1,

        // 스킬을 이용한 공격
        Skill = 2
    }

    /// <summary>
    /// 채집 행동의 세부 종류
    /// </summary>
    public enum GatherType
    {
        None = 0,

        // 나무 채집
        Wood = 1,

        // 광석 채집
        Ore = 2,

        // 식물이나 약초 등의 채집
        Plant = 3
    }

    /// <summary>
    /// 제작 행동의 세부 종류
    /// </summary>
    public enum CraftType
    {
        None = 0,

        // 새로운 아이템 제작
        Create = 1,

        // 재료를 다른 재료나 아이템으로 가공
        Process = 2
    }

    /// <summary>
    /// 휴식 행동의 세부 종류
    /// </summary>
    public enum RestType
    {
        None = 0,

        // 앉아서 휴식
        Sit = 1,

        // 누워서 휴식
        Lie = 2
    }

    /// <summary>
    /// 대화 행동의 세부 종류
    /// </summary>
    public enum TalkType
    {
        None = 0,

        // 일반적인 대화
        Conversation = 1,

        // 인사
        Greeting = 2,

        // 설득
        Persuade = 3
    }

    /// <summary>
    /// 취미 행동의 세부 종류
    /// </summary>
    public enum HobbyType
    {
        None = 0,

        // 독서
        Reading = 1,

        // 공부
        Study = 2,

        // 낚시
        Fishing = 3,

        // 악기 연주
        PlayingMusic = 4
    }


}