using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum CharacterStateType
{
    None = 0,
    Idle =1,
    Move =2,
    Attack =3,
    Gather =4


}

public enum Grade
{
    None = 0,
    Normal = 1,
    Rare = 2,
    Unique = 3,
    Epic = 4,
    Legend = 5
}

public enum Talent
{
    None = 0,   // 성장 불가
    Genius = 1, // 경험치 요구량 가장 낮음
    Normal = 2,
    Poor = 3    // 경험치 요구량 가장 높음
}
