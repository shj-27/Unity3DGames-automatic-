using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface MainInterfaces
{

}
/*
=========================================================
[ 2. 상태 인터페이스 ]
---------------------------------------------------------
- 실제 행동을 수행하는 객체의 설계도
- 상태는 반드시 3단계를 가짐

Enter  : 상태에 처음 진입할 때 1회 실행
Update : 상태가 유지되는 동안 매 프레임 실행
Exit   : 다른 상태로 바뀔 때 1회 실행
=========================================================
*/
public interface ICharacterState
{
    void Enter();      // 상태 진입
    void Update();     // 상태 진행
    void Exit();       // 상태 종료
}


