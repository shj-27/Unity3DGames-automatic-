using UnityEngine;

/// <summary>
/// 아이템 관련 공통 관리
///
/// 현재 역할:
/// - 캐릭터 ID를 이용하여 아이템 소유자를 찾음
///
/// 아직 담당하지 않는 것:
/// - 아이템 획득
/// - 아이템 추가
/// - 아이템 삭제
/// - 아이템 드랍
/// - 창고
/// - 퀘스트 보상
///
/// 아이템을 얻는 경로가 여러 개이기 때문에
/// 공통적으로 사용할 수 있는 아이템 관리 역할을 담당한다.
/// </summary>
public class ItemManager : MonoBehaviour
{
    [Header("캐릭터 인벤토리")]
    [SerializeField] private CharacterInventory characterInventory;


    /// <summary>
    /// 캐릭터 ID로 아이템 소유자를 찾는다.
    ///
    /// 예:
    /// "C10001" → C10001 캐릭터의 전체 데이터 반환
    /// </summary>
    public CharacterCreateData GetOwner(string characterId)
    {
        if (string.IsNullOrEmpty(characterId))
        {
            Debug.LogError("캐릭터 ID가 없음");
            return null;
        }

        if (characterInventory == null)
        {
            Debug.LogError("CharacterInventory가 연결되지 않음");
            return null;
        }

        return characterInventory.GetCharacterByID(characterId);
    }
}