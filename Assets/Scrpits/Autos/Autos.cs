using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Autos : MonoBehaviour
{
    /// <summary>
    /// 범용 자동 생성 코루틴
    /// interval : 몇 초마다 체크
    /// maxAmount : 최대 물량
    /// getCurrentAmount : 현재 개수를 가져오는 함수
    /// spawnAction : 생성 실행 함수
    /// </summary>

    //Func  = 물어보는 역할
    //Action = 시키는 역할
    // 외부 스크립트가 읽는 락 상태
    public IEnumerator AutoSpawn(
        float interval,
        int maxAmount,
        Func<int> getCurrentAmount,
        Action spawnAction)
    {
        while (true)
        {
            if (getCurrentAmount() < maxAmount)
            {
                spawnAction();
            }

            yield return new WaitForSeconds(interval);
        }
    }

    /// <summary>
    /// 범용 대기 후 확률에 따라 메서드 실행
    /// waitTime : 대기 시간
    /// probability : 메서드1이 실행될 확률 (0~1)
    /// method1 : 확률에 성공했을 때 실행
    /// method2 : 확률에 실패했을 때 실행
    /// </summary>
    public IEnumerator WaitCoroutine(
        float waitTime,
        float probability,
        Action method1,
        Action method2)
    {
        yield return new WaitForSeconds(waitTime);

        if (UnityEngine.Random.value < probability)
        {
            method1?.Invoke();
        }
        else
        {
            method2?.Invoke();
        }
    }
}
