using System;
using System.Collections.Generic;
using CharacterEnumList;
using CharacterAction;
using RelationshipType;
using UnityEngine;

[System.Serializable]
public class CharacterData
{
    // 캐릭터 ID
    public string id;
    

    // 캐릭터 이름
    public string lineageNameId; // 성씨 JSON ID
    public string lineageName;
    public string givenName;

    public Sprite portrait; //캐릭터 외형

    // 외형 파츠
    public Sprite[] portraits;

    public GameObject head;
    public GameObject top;
    public GameObject bottom;

    //스탯
    public int hp;
    public int mp;

    public int str;
    public int agi;
    public int intel;
    public int wis;
    public int cha;

    public Grade grade;
    public JobType jobType;
    public RaceType raceType;   

    // 캐릭터 기본정보
    public string familyAffiliation; // 가문 소속 ID
    public string groupAffiliation;  // 집단 소속 ID
    public GenderType genderType; //성별
    public int age;

    // 캐릭터 관계 데이터
    public Family family;
    public Relatives relatives; 
    public SocialRelationships socialRelationships;
    public GrudgeRelationships grudgeRelationships;
    public PartyRoles partyRoles; 

    // 캐릭터 성격 데이터
    public CharacterPersonalityData personalityData;

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