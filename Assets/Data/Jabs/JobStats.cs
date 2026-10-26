
using CharacterEnumList;
using RelationshipType;
using UnityEngine;

[CreateAssetMenu(menuName = "Game/Job Stats")]
public class JobStats : ScriptableObject
{
    [Header("¿ÜÇü ÇÁ¸®ÆÕ")]

    public JobType jobType;
    public RaceType raceType;

    public HeadData[] heads;
    public GameObject[] bodyPrefab;
    public GameObject[] legPrefab;

    public StatRangeByGrade hp;
    public StatRangeByGrade mp;

    public StatRangeByGrade str;
    public StatRangeByGrade agi;
    public StatRangeByGrade intel;
    public StatRangeByGrade wis;
    public StatRangeByGrade cha;
}
