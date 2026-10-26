using UnityEngine;

/// <summary>
/// 캐릭터 성격 데이터 보관
/// </summary>
[CreateAssetMenu(fileName = "CharacterPersonalityDatabase", menuName = "Game/Character/Personality Database")]
public class CharacterPersonalityDatabase : ScriptableObject
{
    // 보관할 성격 데이터 목록
    [SerializeField]
    private CharacterPersonalityData[] personalities;

    /// <summary>
    /// 보관된 성격 데이터 목록 반환
    /// </summary>
    public CharacterPersonalityData[] Personalities => personalities;
}