using UnityEngine;

public class Execution : MonoBehaviour
{
    public void TryAddCharacter(CharacterFactory factory, CharacterInventory inventory)
    {
        // 1. 캐릭터 관련 전체 데이터 생성
        CharacterCreateData createData = factory.CreateCharacter();

        if (createData == null)
        {
            Debug.LogError("[Execution] 캐릭터 생성 실패");
            return;
        }

        Debug.Log($"[Execution] 캐릭터 생성 완료: {createData.characterData.id}");


        // 2. 캐릭터 인벤토리에 추가
        inventory.AddCharacter(createData);

        Debug.Log($"[Execution] 인벤토리 추가 완료: {createData.characterData.id}");


        // 3. UI 갱신 호출
        Debug.Log("[Execution] UI 갱신 호출");

        UIManager.Instance.RefreshCharacterInventory(inventory);
    }
}