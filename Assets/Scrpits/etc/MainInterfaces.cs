using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface MainInterfaces
{

}
/*
=========================================================
[ 캐릭터 행동 인터페이스 ]
---------------------------------------------------------
- 실제 캐릭터 행동을 수행하는 객체의 설계도
- 모든 행동은 5단계의 생명주기를 가짐

Enter       : 행동을 처음 시작할 때 1회 실행
Update      : 행동이 실행되는 동안 매 프레임 실행
FixedUpdate : 물리 연산 타이밍에 실행
LateUpdate  : 모든 Update 이후 실행
Exit        : 행동을 종료할 때 1회 실행
=========================================================
*/
public interface ICharacterAction
{
    void Enter();
    void Update();
    void FixedUpdate();
    void LateUpdate();
    void Exit();
}


