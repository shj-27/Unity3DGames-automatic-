using UnityEngine;

[CreateAssetMenu(
    fileName = "CharacterPersonalityDatabaseList",
    menuName = "Game/Character/Personality Database List"
)]
public class CharacterPersonalityDatabaseList : ScriptableObject
{
    [SerializeField]
    private CharacterPersonalityDatabase[] databases;

    public CharacterPersonalityDatabase[] Databases => databases;
}