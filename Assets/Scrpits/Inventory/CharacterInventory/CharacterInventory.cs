using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 보유 캐릭터 관리
///
/// 역할:
/// - 플레이어가 보유한 캐릭터 목록 관리
/// - 캐릭터 추가 / 제거
/// - ID를 통한 캐릭터 검색
///
/// 주의:
/// 이 클래스는 캐릭터 내부 데이터 관리가 아니라
/// "보유하고 있는 캐릭터 목록"을 관리한다.
/// </summary>
public class CharacterInventory : MonoBehaviour
{
    [Header("인벤토리 규칙 데이터")]
    [SerializeField] private CharacterInventoryData data;


    [Header("보유 캐릭터")]
    // 기존 CharacterData만 저장하던 것을
    // 캐릭터 관련 전체 데이터를 저장하도록 변경
    //
    // CharacterCreateData
    // ├── CharacterData
    // ├── CharacterEquipmentData
    // └── CharacterPersonalInventoryData
    //
    [SerializeField]
    private List<CharacterCreateData> characters =
        new List<CharacterCreateData>();


    // 외부에서는 목록 확인만 가능
    public List<CharacterCreateData> Characters => characters;


    // 인벤토리 규칙 데이터
    public CharacterInventoryData Data => data;


    // 현재 보유 캐릭터 수
    public int Count => characters.Count;



    /// <summary>
    /// 캐릭터 보관 공간이 가득 찼는지 확인
    /// </summary>
    public bool IsFull()
    {
        return characters.Count >= data.MaxBagSize;
    }



    /// <summary>
    /// 자동 캐릭터 생성 제한 확인
    /// </summary>
    public bool IsAutoCreateFull()
    {
        return characters.Count >= data.MaxAutoCreateCount
            || characters.Count >= data.MaxBagSize;
    }



    /// <summary>
    /// 캐릭터 추가
    ///
    /// 추가되는 데이터:
    /// - 캐릭터 기본 정보
    /// - 장착 장비 정보
    /// - 개인 소지품 정보
    /// </summary>
    public bool AddCharacter(CharacterCreateData character)
    {
        if (character == null ||
            character.characterData == null)
        {
            Debug.LogError("캐릭터 데이터 없음");
            return false;
        }


        if (IsFull())
        {
            Debug.Log("캐릭터 인벤토리가 가득 참");
            return false;
        }


        characters.Add(character);

        return true;
    }



    /// <summary>
    /// 캐릭터 제거
    ///
    /// 캐릭터 전체 데이터 제거
    /// (기본 정보 + 장비 + 개인 소지품)
    /// </summary>
    public void RemoveCharacter(CharacterCreateData character)
    {
        if (characters.Contains(character))
        {
            characters.Remove(character);
        }
    }



    /// <summary>
    /// 캐릭터 ID 검색
    ///
    /// ID는 CharacterData 내부에 존재하기 때문에
    /// character.characterData.id 로 접근
    /// </summary>
    public CharacterCreateData GetCharacterByID(string id)
    {
        Debug.Log($"검색 시작 : {id}");


        CharacterCreateData character =
            characters.Find(character =>
                character.characterData.id == id);


        return character;
    }
}