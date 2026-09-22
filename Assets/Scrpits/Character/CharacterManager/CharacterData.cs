using System;
using UnityEngine;

[System.Serializable]
public class CharacterData
{

    public string id;
    public EntityType entityType;
    //public GameObject appearancePrefab;
    public Sprite portrait;

    //외형 파츠
    public GameObject head;   // 머리
    public Sprite[] portraits;   // 그대로 저장 (전체 유지)

    public GameObject top;    // 상의
    public GameObject bottom; // 하의

    // ===== 신체 =====
    public float eyes;   // 시야
    // public float hearing; // 청각
    // public float smell;   // 후각
    // public float speed;   // 이동 능력
    // public float reach;   // 팔 길이

    // ===== 능력치 =====
    public int hp;
    public int mp;

    public int str;
    public int agi;
    public int intel;
    public int wis;
    public int cha;

    public float moveSpeed; // 이동 속도

    public Grade grade;
    public JobType jobType;

    // ===== 욕구 =====
    public float fatigue = 100f; // 피로도 (100 = 완전 휴식)
    public float hunger = 0f;    // 배고픔 (0 = 배부름)
}