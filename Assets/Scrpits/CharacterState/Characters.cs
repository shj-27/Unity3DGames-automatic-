using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//모든 랜덤을 이어 받아서 캐릭터의 정보를 확정적으로 선언하는 스크립트
//캐릭터의 능력치를 받는게 아님 여기에서는 선언한 뒤에 캐릭터 라는 오브젝트는 해당 값을 줘는 역할
public class Characters : MonoBehaviour
{
    [SerializeField] private int minRange;
    [SerializeField] private int maxRange;

    public int GetRandomRange()
    {
        minRange = 1;
        maxRange = 5;
        return Randoms.RandomInt(minRange, maxRange);
    }
}
