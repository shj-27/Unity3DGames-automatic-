using System;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CharacterData
{
    public string id;

    public Sprite portrait;

    // 외형 파츠
    public GameObject head;
    public Sprite[] portraits;

    public GameObject top;
    public GameObject bottom;

    public int hp;
    public int mp;

    public int str;
    public int agi;
    public int intel;
    public int wis;
    public int cha;

    public Grade grade;
    public JobType jobType;

    // 캐릭터가 사용할 행동
    [NonSerialized]
    public Dictionary<CharacterActionType, ICharacterAction> actions
        = new Dictionary<CharacterActionType, ICharacterAction>();

    /// <summary>
    /// 캐릭터가 사용할 행동 등록
    /// </summary>
    public void AddAction(
        CharacterActionType type,
        ICharacterAction action)
    {
        actions[type] = action;
    }
}