using System;
using UnityEngine;

/// <summary>
/// 소모품 아이템 데이터
/// 
/// 소모품 사용 시 캐릭터의 기본 능력치 또는
/// 상태 이상에 효과를 적용한다.
/// </summary>
[Serializable]
public class ConsumableItemData
{
    /// <summary>
    /// 아이템 이름
    /// </summary>
    public string itemName;

    /// <summary>
    /// 아이템 이미지
    /// 인벤토리 및 아이템 사용 UI에서 표시
    /// </summary>
    public Sprite itemSprite;

    public StatEffectData[] statEffects;


    /// <summary>
    /// 효과를 적용할 상태 이상
    /// </summary>
    public StatusEffectList.StatusEffect targetStatusEffect;

    /// <summary>
    /// 상태 이상을 회복하는지 여부
    /// true  = 상태 이상 회복
    /// false = 상태 이상 부여
    /// </summary>
    public bool isRecovery;
}