using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class IntRangeByGrade
{
    public Vector2Int normal;
    public Vector2Int rare;
    public Vector2Int unique;
    public Vector2Int epic;
    public Vector2Int legend;

    public Vector2Int GetRange(Grade grade)
    {
        switch (grade)
        {
            case Grade.Normal: return normal;
            case Grade.Rare: return rare;
            case Grade.Unique: return unique;
            case Grade.Epic: return epic;
            case Grade.Legend: return legend;
            default:
                Debug.LogError("肋给等 Grade");
                return Vector2Int.zero;
        }
    }
}

// float 裹困
[System.Serializable]
public class FloatRangeByGrade
{
    public Vector2 normal;
    public Vector2 rare;
    public Vector2 unique;
    public Vector2 epic;
    public Vector2 legend;

    public Vector2 GetRange(Grade grade)
    {
        switch (grade)
        {
            case Grade.Normal: return normal;
            case Grade.Rare: return rare;
            case Grade.Unique: return unique;
            case Grade.Epic: return epic;
            case Grade.Legend: return legend;
            default:
                Debug.LogError("肋给等 Grade");
                return Vector2.zero;
        }
    }
}
