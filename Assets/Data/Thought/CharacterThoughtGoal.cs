using UnityEngine;

/// <summary>
/// 캐릭터가 생각할 수 있는 하나의 목표
///
/// 역할:
/// - CharacterThought가 선택할 수 있는 목표를 정의
/// - 목표의 구체적인 실행 방법은 담당하지 않음
///
/// 예:
/// - 짐 운반
/// - 식사
/// - 휴식
/// - 작업
/// </summary>

/// <summary>
/// 캐릭터가 생각하는 목표 데이터
/// </summary>
[CreateAssetMenu(fileName = "CharacterThoughtGoal", menuName = "Character/Thought Goal")]
public class CharacterThoughtGoal : ScriptableObject
{
    // 누가 (Who)
    public string who;

    // 언제 (When)
    public string when;

    // 어디서 (Where)
    public string where;

    // 무엇을 (What)
    public string what;

    // 어떻게 (How)
    public string how;

    // 왜 (Why)
    public string why;
}