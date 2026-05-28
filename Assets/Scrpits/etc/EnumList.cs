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