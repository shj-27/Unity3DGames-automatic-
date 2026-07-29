using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterInventoryUI : MonoBehaviour
{
    [Header("Data")]
    [SerializeField] private CharacterInventory inventory;


    [SerializeField]
    private GameObject slotParent;

    [Header("UI")]
    [SerializeField] private List<CharacterSlotButton> slots = new();

    private void OnValidate()
    {
        if (slotParent == null)
            return;
        slots.Clear();
        slots = new List<CharacterSlotButton>(
            slotParent.GetComponentsInChildren<CharacterSlotButton>(true)
        );
    }

    private void OnEnable()
    {
        
    }

    // 인벤토리 UI 갱신
    public void Refresh(CharacterInventory inventory)
    {
       

        foreach (CharacterData data in inventory.Characters)
        {
            CreateSlot(data);
        }
    }

    // 슬롯 생성
    private void CreateSlot(CharacterData data)
    {
        var list = inventory.Characters;

        for (int i = 0; i < slots.Count; i++)
        {
            if (i < list.Count)
            {
                slots[i].gameObject.SetActive(true);
                slots[i].SetData(list[i]);
            }
            else
            {
                slots[i].gameObject.SetActive(false);
            }
        }
    }

    // 기존 슬롯 삭제
    private void Clear()
    {
        for (int i = 0; i < slots.Count; i++)
        {
            Destroy(slots[i].gameObject);
        }

        slots.Clear();
    }
}
