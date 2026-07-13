using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Game/Job Stats")]
public class JobStats : ScriptableObject
{
    [Header("외형 프리팹")]

    public JobType jobType;


    public HeadData[] heads;
    public GameObject[] bodyPrefab;
    public GameObject[] legPrefab;

    // ===== Float 능력치 =====
    public FloatRangeByGrade eyes;

    // ===== Int 능력치 =====
    public IntRangeByGrade hp;
    public IntRangeByGrade mp;

    public IntRangeByGrade str;
    public IntRangeByGrade agi;
    public IntRangeByGrade intel;
    public IntRangeByGrade wis;
    public IntRangeByGrade cha;
}
