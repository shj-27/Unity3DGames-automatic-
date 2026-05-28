using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Execution : MonoBehaviour
{
    public void TryAddCharacter(CharacterFactory factory, CharacterInventory inventory)
    {
        CharacterData data = factory.CreateCharacterData();
        inventory.AddCharacter(data);

        Debug.Log("캐릭터 추가 실행됨");
    }
}
