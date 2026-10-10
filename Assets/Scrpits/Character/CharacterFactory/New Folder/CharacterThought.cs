using UnityEngine;

/// <summary>
/// 캐릭터의 생각을 담당하는 뇌
///
/// 역할:
/// - 자신이 어떤 Character의 Thought인지 확인
/// - 현재 생각 중인지 관리
/// - 행동 자체를 직접 관리하지 않음
/// - 실제 행동은 CharacterActionManager / Character가 담당
/// </summary>
public class CharacterThought : MonoBehaviour
{
    // 자신이 연결된 캐릭터
    private Character character;

    // 자신의 캐릭터 ID
    private string characterId;

    // 현재 새로운 생각을 하고 있는지
    private bool isThinking = false;

    CharacterThoughtGoal[] goals;

    /// <summary>
    /// 자신이 어떤 캐릭터의 Thought인지 확인
    /// </summary>
    public void Identify()
    {
        character = GetComponent<Character>();

        if (character == null)
        {
            Debug.LogError(
                $"[CharacterThought] {gameObject.name} | " +
                "Character를 찾을 수 없음"
            );

            return;
        }

        characterId = character.ID;

        Debug.Log(
            $"[CharacterThought] 나는 {characterId} 캐릭터의 Thought"
        );
    }
}