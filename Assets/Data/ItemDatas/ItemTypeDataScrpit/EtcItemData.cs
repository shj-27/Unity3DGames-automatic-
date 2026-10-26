using System;
using UnityEngine;
using ItemEnumList;
[Serializable]
public class EtcItemData
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
    /// 기타 아이템의 세부 종류
    /// </summary>
    public EtcType etcType;
}