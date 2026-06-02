using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Execution : MonoBehaviour
{
    public void TryAddCharacter(CharacterFactory factory, CharacterInventory inventory)
    {
        // 1. 데이터 생성
        CharacterData data = factory.CreateCharacterData();
        Debug.Log($"[Execution] 캐릭터 생성 완료: {data.id}");

        // 2. 인벤토리 추가
        inventory.AddCharacter(data);
        Debug.Log($"[Execution] 인벤토리 추가 완료: {data.id}");

        // 3. UI 갱신 호출
        Debug.Log("[Execution] UI 갱신 호출");
        UIManager.Instance.RefreshCharacterInventory(inventory);
    }
}

