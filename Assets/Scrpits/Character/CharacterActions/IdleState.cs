using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : ICharacterState
{
    private Actions character;

    public IdleState(Actions character)
    {
        this.character = character;
    }

    public void Enter()
    {
        Debug.Log("대기 시작");
    }

    public void Update()
    {
        // 생각 시스템에게 판단 기회 제공
        // 배고프면 Gather
        // 적 발견하면 Attack
        // 목적지 있으면 Move
    }

    public void FixedUpdate() { }

    public void LateUpdate() { }

    public void Exit()
    {
        Debug.Log("대기 종료");
    }


}
