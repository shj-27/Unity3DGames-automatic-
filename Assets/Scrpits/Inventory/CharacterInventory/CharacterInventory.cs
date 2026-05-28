using System.Collections.Generic;
using UnityEngine;

public class CharacterInventory : MonoBehaviour
{
    [Header("인벤토리 규칙 데이터")]
    [SerializeField] private CharacterInventoryData data;

    [Header("보유 캐릭터")]
    [SerializeField] private List<CharacterData> characters = new List<CharacterData>();

    public List<CharacterData> Characters => characters;

    //외부 접근 허용 (읽기 전용)
    public CharacterInventoryData Data => data;


    // 현재 개수
    public int Count => characters.Count;

    // 가방이 꽉 찼는지
    public bool IsFull()
    {
        return characters.Count >= data.MaxBagSize;
    }

    // 캐릭터 생산 조건
    public bool IsAutoCreateFull()
    {
        return characters.Count >= data.MaxAutoCreateCount
        || characters.Count >= data.MaxBagSize;
    }

    // 캐릭터 추가
    public bool AddCharacter(CharacterData character)
    {
        if (character == null)
        {
            Debug.LogError("캐릭터 데이터 없음");
            return false;
        }

        if (IsFull())
        {
            Debug.Log("가방이 가득 참");
            return false;
        }

        characters.Add(character);
        return true;
    }

    // 캐릭터 제거
    public void RemoveCharacter(CharacterData character)
    {
        if (characters.Contains(character))
        {
            characters.Remove(character);
        }
    }

    //id를 찾아줘 같은 개념
    public CharacterData GetCharacterByID(string id)
    {
        Debug.Log($"검색 시작 : {id}");

        CharacterData data = characters.Find(character => character.id == id);

        if (data != null)
        {
            Debug.Log($"찾음 : {data.id}");
        }
        else
        {
            Debug.LogError($"못 찾음 : {id}");
        }

        return data;
    }
}