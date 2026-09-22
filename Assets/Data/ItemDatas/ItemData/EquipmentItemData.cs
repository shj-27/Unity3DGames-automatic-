using System;
using UnityEngine;

[Serializable]
public class EquipmentItemData
{
    /// <summary>
    /// 아이템 이름
    /// </summary>
    public string itemName;

    /// <summary>
    /// 아이템 이미지
    /// </summary>
    public Sprite itemSprite;


    /// <summary>
    /// 장비 종류
    /// </summary>
    public EquipmentList.EquipmentType equipmentType;


    /// <summary>
    /// 저주받은 장비인지 여부
    /// true  = 저주 장비
    /// false = 일반 장비
    /// </summary>
    public bool isCursed;


    public StatEffectData[] statEffects;


    /// <summary>
    /// 효과를 적용할 상태 이상
    /// </summary>
    public StatusEffectList.StatusEffect targetStatusEffect;
}