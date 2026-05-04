using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Game/Job Stats")]
public class JobStats : ScriptableObject
{
    public JobType jobType;

    public StatRangeByGrade hp;
    public StatRangeByGrade mp;

    public StatRangeByGrade str;
    public StatRangeByGrade agi;
    public StatRangeByGrade intel;
    public StatRangeByGrade wis;
    public StatRangeByGrade cha;
}
