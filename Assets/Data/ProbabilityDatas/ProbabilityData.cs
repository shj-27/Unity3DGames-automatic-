using RelationshipType;
using UnityEngine;

[System.Serializable]
public class RaceProbability
{
    public RaceType raceType;

    [Range(0, 10000)]
    public int probability;
}

[CreateAssetMenu(fileName = "CharacterProbabilityData", menuName = "Game/Character/Probability Data")]
public class CharacterProbabilityData : ScriptableObject
{
    [Header("Race Probability")]
    [Range(0, 10000)]
    public int humanProbability;

    public RaceProbability[] raceProbabilities;
}