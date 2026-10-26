using RelationshipType;
using UnityEngine;

[System.Serializable]
public class RaceProbability
{
    public RaceType raceType;

    [Range(0, 10000)]
    public int probability;

    [Header("Age Range")]
    public Vector2Int ageRange = new Vector2Int(17, 100);
}

[CreateAssetMenu(fileName = "CharacterProbabilityData", menuName = "Game/Character/Probability Data")]
public class ProbabilityData : ScriptableObject
{
    [Header("Human")]
    [Range(0, 10000)]
    public int humanProbability;

    public Vector2Int humanAgeRange = new Vector2Int(17, 100);

    [Header("Other Races")]
    public RaceProbability[] raceProbabilities;
}