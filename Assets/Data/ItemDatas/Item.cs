using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Game/Item Data")]
public class Item : ScriptableObject
{
    public TypeData typeData;

    // 아이템 종류의 고유 ID
    public int id;

    // 아이템 종류
    public ItemType itemType;

    // 아이템 타입별 데이터
    public ConsumableItemData consumableData;
    public EquipmentItemData equipmentData;
    public MaterialItemData materialData;
    public EtcItemData etcData;
    public EventItemData eventData;

}
