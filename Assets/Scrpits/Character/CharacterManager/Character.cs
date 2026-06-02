using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] private string id;
    private bool isInitialized = false;
    private CharacterData characterData;
    // 외부에서 읽기만 가능
    public string ID => id;

    [SerializeField] private Transform headSocket;
    [SerializeField] private Transform bodySocket;
    [SerializeField] private Transform legSocket;

    private CharacterPart headPart;
    private CharacterPart bodyPart;
    private CharacterPart legPart;

    // ID는 단 한 번만 세팅
    public void SetID(string newId)
    {
        if (!string.IsNullOrEmpty(id))
            return; //이미 있으면 변경 금지

        id = newId;
    }

    //머리 설정
    private void RefreshAppearance()
    {
        GameObject headObject =
        Instantiate(characterData.head, headSocket);

        headPart = headObject.GetComponent<CharacterPart>();

        if (headPart != null)
        {
            headPart.Initialize(this);
        }

        // 몸통
        GameObject bodyObject =
            Instantiate(characterData.top, bodySocket);

        bodyPart = bodyObject.GetComponent<CharacterPart>();

        if (bodyPart != null)
        {
            bodyPart.Initialize(this);
        }

        // 다리
        GameObject legObject =
            Instantiate(characterData.bottom, legSocket);

        legPart = legObject.GetComponent<CharacterPart>();

        if (legPart != null)
        {
            legPart.Initialize(this);
        }
    }

    private void Start()
    {
        CharacterInventory inventory = CharacterManager.Instance.Inventory;

        characterData = inventory.GetCharacterByID(id);

        if (characterData == null)
        {
            
            return;
        }
        RefreshAppearance();
        
    }
}
