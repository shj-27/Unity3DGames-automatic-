using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : MonoBehaviour
{
    [SerializeField] private CharacterFactory factory;
    [SerializeField] private Character targetCharacter; // 이미 씬에 있는 캐릭터

    void Start()
    {
        if (factory == null || targetCharacter == null)
        {
            Debug.LogError("연결 안됨");
            return;
        }

        factory.ApplyData(targetCharacter);

        Debug.Log("데이터 적용 완료 테스트");
    }
}
