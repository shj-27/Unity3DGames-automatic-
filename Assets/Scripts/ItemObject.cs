using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "ScriptableObjects/Item")]
public class ItemObject : ScriptableObject
{
    public string itemName;
    public GameObject prefabs;
    public GameObject prefabsBox;

    [Header("아이템 개수")]
    public int itemCount;                 //최초 개수 만큼 아이템 생산 한 뒤에 pull로 정리
}
