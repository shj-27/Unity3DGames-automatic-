using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class StatRangeByGrade
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
                Debug.LogError("Àß¸øµÈ Grade");
                return Vector2Int.zero;
        }
    }
}
