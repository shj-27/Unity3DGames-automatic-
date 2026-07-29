using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CharacterEquipmentData
{
    // 현재 장착 장비
    public ItemData rightHand;
    public ItemData leftHand;
    public ItemData armor;
    public ItemData shoes;
    public ItemData accessory1;
    public ItemData accessory2;

    // 예비 장비
    public ItemData reserveRightHand;
    public ItemData reserveLeftHand;
}
