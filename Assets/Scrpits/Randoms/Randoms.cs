using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CharacterEnumList;
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


    /// <summary>
    /// 확률 배열을 이용한 랜덤 추첨
    /// 배열 값은 확률이며, 반환값은 당첨된 배열의 인덱스
    /// </summary>
    public static int RandomFloat(float[] probabilities)
    {
        float totalProbability = 0f;

        for (int i = 0; i < probabilities.Length; i++)
        {
            totalProbability += probabilities[i];
        }

        float roll = RandomFloat(0f, totalProbability);
        float cumulativeProbability = 0f;

        for (int i = 0; i < probabilities.Length; i++)
        {
            cumulativeProbability += probabilities[i];

            if (roll < cumulativeProbability)
            {
                return i;
            }
        }

        return probabilities.Length - 1;
    }


    public static Grade RollGrade()
    {
        float[] probabilities =
        {
        97f,    // Normal: 97%
        2.8f,   // Rare: 2.8%
        0.1f,   // Unique: 0.1%
        0.09f,  // Epic: 0.09%
        0.01f   // Legend: 0.01%
    };

        int result = RandomFloat(probabilities);

        switch (result)
        {
            case 0:
                return Grade.Normal;

            case 1:
                return Grade.Rare;

            case 2:
                return Grade.Unique;

            case 3:
                return Grade.Epic;

            case 4:
                return Grade.Legend;

            default:
                return Grade.Normal;
        }
    }


    /// <summary>
    /// 배열의 크기를 기준으로 무작위 인덱스 반환
    /// </summary>
    public static int RandomIndex<T>(T[] array)
    {
        return Random.Range(0, array.Length);
    }

    /// <summary>
    /// List의 크기를 기준으로 무작위 인덱스 반환
    /// </summary>
    public static int RandomIndex<T>(List<T> list)
    {
        return Random.Range(0, list.Count);
    }

}