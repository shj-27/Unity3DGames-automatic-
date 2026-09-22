using System.Collections.Generic;
using UnityEngine;

public class CharacterInventoryUI : MonoBehaviour
{
    [Header("Data")]
    [SerializeField] private CharacterInventory inventory;


    [SerializeField]
    private GameObject slotParent;


    [Header("UI")]
    [SerializeField]
    private List<CharacterSlotButton> slots = new();



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



    /// <summary>
    /// 캐릭터 인벤토리 UI 갱신
    ///
    /// CharacterInventory는 전체 데이터를 가지고 있지만
    /// 슬롯 UI는 캐릭터 기본 정보만 필요하기 때문에
    /// CharacterData만 전달한다.
    /// </summary>
    public void Refresh(CharacterInventory inventory)
    {
        List<CharacterCreateData> list =
            inventory.Characters;


        for (int i = 0; i < slots.Count; i++)
        {
            if (i < list.Count)
            {
                slots[i].gameObject.SetActive(true);


                // 전체 데이터 중 UI 표시용 데이터만 전달
                slots[i].SetData(
                    list[i].characterData
                );
            }
            else
            {
                slots[i].gameObject.SetActive(false);
            }
        }
    }



    /// <summary>
    /// 슬롯 초기화
    /// </summary>
    private void Clear()
    {
        for (int i = 0; i < slots.Count; i++)
        {
            slots[i].gameObject.SetActive(false);
        }
    }
}