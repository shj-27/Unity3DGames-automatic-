using System;
using UnityEngine;

/// <summary>
/// 재료 아이템 데이터
/// </summary>
[Serializable]
public class MaterialItemData
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
    /// 재료의 종류
    /// 광석 / 목재 / 섬유 / 식욕용
    /// </summary>
    public MaterialItemList.MaterialType materialType;
}