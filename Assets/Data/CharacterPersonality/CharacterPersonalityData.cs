using System;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 캐릭터 성격 데이터
/// </summary>
[CreateAssetMenu(
    fileName = "CharacterPersonality",
    menuName = "Character/Personality"
)]
public class CharacterPersonalityData : ScriptableObject
{
   

    // 성격 이름
    public string personalityName;

    // 성격이 적용하는 능력치와 수치
    public List<StatEffectPersonalityData> statEffects = new List<StatEffectPersonalityData>();


    // 결정 포인트
    // 선택의 순간에 망설이지 않고 결정을 내리는 능력
    // 높을수록 결단력이 강하고, 낮을수록 선택을 망설임
    // 결정 포인트
    [Range(1f, 100f)]
    public float decisionPoint = 50f;

    // 논리적 변수
    // 논리와 근거를 이해하고 외부의 설득을 받아들이는 정도
    // 높을수록 합리적인 설명을 이해하고 설득될 수 있음
    [Range(1f, 100f)]
    public float logicalThinking = 50f;


    // 본능의 감
    // 논리적 분석과 별개로 본능적으로 상황을 판단하고 선택하는 성향
    // 높을수록 본능적인 판단의 영향이 강함
    [Range(1f, 100f)]
    public float instinctSense = 50f;
}

