using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    private string id;
    private CharacterData data;

    private int maxHP;
    private int currentHP;

    private int maxMP;
    private int currentMP;

    private int str;
    private int agi;
    private int intel;
    private int wis;
    private int cha;

    public void SetData(CharacterData newData)
    {
        data = newData;

        // ID
        id = data.id;

        // HP
        maxHP = data.hp;
        currentHP = maxHP;

        // MP
        maxMP = data.mp;
        currentMP = maxMP;

        // 기본 능력치
        str = data.str;
        agi = data.agi;
        intel = data.intel;
        wis = data.wis;
        cha = data.cha;

        OnInitialized();
    }
    private void OnInitialized()
    {
        Debug.Log($"초기화 완료 ID: {id} | HP: {currentHP}/{maxHP}");
    }
    public CharacterData GetData()
    {
        return data;
    }
}
