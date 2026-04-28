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
    void Enter();        // 상태에 처음 진입할 때 1회 실행 (초기화, 애니메이션 시작 등)

    void Update();       // 상태가 유지되는 동안 매 프레임 실행 (일반 로직 처리)

    void FixedUpdate();  // 상태 유지 중 물리 연산 타이밍에 실행 (이동, Rigidbody 처리)

    void LateUpdate();   // 모든 Update 이후 실행 (카메라, 보정, 최종 위치 정리)

    void Exit();         // 상태를 벗어날 때 1회 실행 (정리, 애니메이션 종료 등)
}


