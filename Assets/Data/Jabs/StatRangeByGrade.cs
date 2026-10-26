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

    public Vector2Int GetRange(CharacterEnumList.Grade grade)
    {
        switch (grade)
        {
            case CharacterEnumList.Grade.Normal: return normal;
            case CharacterEnumList.Grade.Rare: return rare;
            case CharacterEnumList.Grade.Unique: return unique;
            case CharacterEnumList.Grade.Epic: return epic;
            case CharacterEnumList.Grade.Legend: return legend;
            default:
                Debug.LogError("Àß¸øµÈ Grade");
                return Vector2Int.zero;
        }
    }
}
