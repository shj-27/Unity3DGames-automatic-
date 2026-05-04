using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Randoms : MonoBehaviour
{
    /// <summary>
    /// 정수 랜덤 (min 포함, max 포함)
    /// </summary>
    public static int RandomInt(int min, int max)
    {
        return Random.Range(min, max + 1);
    }

    /// <summary>
    /// 실수 랜덤 (min 포함, max 포함)
    /// </summary>
    public static float RandomFloat(float min, float max)
    {
        return Random.Range(min, max);
    }

    public static Grade RollGrade()
    {
        float roll = RandomFloat(0f, 100f);

        if (roll < 97f)
            return Grade.Normal;

        if (roll < 99.8f) // 97 + 2.8
            return Grade.Rare;

        if (roll < 99.9f) // +0.1
            return Grade.Unique;

        if (roll < 99.99f) // +0.09
            return Grade.Epic;

        return Grade.Legend; // 0.01
    }
   
   

     
}
