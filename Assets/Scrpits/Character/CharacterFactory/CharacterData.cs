using System;
using UnityEngine;

[System.Serializable]
public class CharacterData
{

    public string id;

    //public GameObject appearancePrefab;
    public Sprite portrait;

    //외형 파츠
    public GameObject head;   // 머리
    public Sprite[] portraits;   // 그대로 저장 (전체 유지)

    public GameObject top;    // 상의
    public GameObject bottom; // 하의

    public int hp;
    public int mp;

    public int str;
    public int agi;
    public int intel;
    public int wis;
    public int cha;

    public Grade grade;
    public JobType jobType;
}