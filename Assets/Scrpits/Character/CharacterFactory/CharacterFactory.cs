using RelationshipType;
using CharacterEnumList;
using CharacterAction;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 캐릭터 생성 전용 Factory
/// </summary>
public class CharacterFactory : MonoBehaviour
{
    [SerializeField] private JobStatsDatabase jobStatsDatabase;
    [SerializeField] private TypeData characterTypeData;
    [SerializeField] private CharacterPersonalityDatabase personalityDatabase;
    [SerializeField] private CharacterProbabilityData probabilityData;
    [SerializeField] private CharacterActionManager actionManager;
    [SerializeField] private RandomNames randomNames;

    private int currentId = 10001;

    /// <summary>
    /// JobType.None인 기본 능력치 데이터 가져오기
    /// </summary>
    private JobStats GetDefaultJob()
    {
        if (jobStatsDatabase == null ||
            jobStatsDatabase.jobStatsArray == null)
        {
            return null;
        }

        foreach (JobStats jobStats in jobStatsDatabase.jobStatsArray)
        {
            if (jobStats != null && jobStats.jobType == JobType.None)
            {
                Debug.Log(jobStats.jobType + "입니다");
                Debug.Log(jobStats.name + "입니다");
                return jobStats;
            }
        }

        Debug.Log(jobStatsDatabase.jobStatsArray.Length + "개의 JobStats를 확인했지만 JobType.None이 없습니다.");
        return null;
    }

    /// <summary>
    /// 캐릭터 전체 데이터 생성
    /// </summary>
    public CharacterCreateData CreateCharacter()
    {
        if (characterTypeData == null ||
            actionManager == null ||
            probabilityData == null)
        {
            return null;
        }

        JobStats baseJob = GetDefaultJob();

        if (baseJob == null)
            return null;

        CharacterCreateData result = new CharacterCreateData();
        CharacterData characterData = new CharacterData();

        // 캐릭터 ID
        CreateID(characterData);

        // 종족
        CreateRace(characterData);

        // 성씨, 이름, 가문 소속
        CreateCharacterName(characterData);

        // 등급 및 직업
        CreateGradeAndJob(characterData, baseJob);

        // 외형 전체
        CreateAppearance(characterData, baseJob);

        // 스탯
        CreateStats(characterData, baseJob);

        // 성격
        CreatePersonality(characterData);

        // 행동
        CreateActions(characterData);

        // 장비 데이터
        CharacterEquipmentData equipmentData =
            new CharacterEquipmentData();

        // 개인 소지품 데이터
        CharacterPersonalInventoryData inventoryData =
            new CharacterPersonalInventoryData();

        // 최종 결과 취합
        result.characterData = characterData;
        result.equipmentData = equipmentData;
        result.inventoryData = inventoryData;

        return result;
    }

    /// <summary>
    /// 캐릭터 ID 생성
    /// </summary>
    private void CreateID(CharacterData characterData)
    {
        characterData.id = $"{characterTypeData.prefix}{currentId++}";
    }

    /// <summary>
    /// 종족 랜덤 선택
    /// </summary>
    private void CreateRace(CharacterData characterData)
    {
        int roll = Randoms.RandomInt(1, 10000);

        if (roll <= probabilityData.humanProbability)
        {
            characterData.raceType = RaceType.Human;
            return;
        }

        RaceProbability[] raceProbabilities =
            probabilityData.raceProbabilities;

        if (raceProbabilities == null ||
            raceProbabilities.Length == 0)
        {
            return;
        }

        int totalProbability = 0;

        foreach (RaceProbability raceProbability in raceProbabilities)
        {
            if (raceProbability != null &&
                raceProbability.probability > 0)
            {
                totalProbability += raceProbability.probability;
            }
        }

        if (totalProbability <= 0)
            return;

        int raceRoll = Randoms.RandomInt(1, totalProbability);
        int cumulativeProbability = 0;

        foreach (RaceProbability raceProbability in raceProbabilities)
        {
            if (raceProbability == null ||
                raceProbability.probability <= 0)
            {
                continue;
            }

            cumulativeProbability += raceProbability.probability;

            if (raceRoll <= cumulativeProbability)
            {
                characterData.raceType = raceProbability.raceType;
                return;
            }
        }
    }

    /// <summary>
    /// 성씨, 이름, 가문 소속 ID 생성
    /// </summary>
    private void CreateCharacterName(CharacterData characterData)
    {
        if (randomNames == null)
            return;

        randomNames.EnsureInitialized();

        RandomNames.NameEntry[] lineageNames = randomNames.LineageNames;
        RandomNames.NameEntry[] givenNames = randomNames.GivenNames;

        if (lineageNames == null || lineageNames.Length == 0 ||
            givenNames == null || givenNames.Length == 0)
        {
            return;
        }

        RandomNames.NameEntry selectedLineage =
            lineageNames[Randoms.RandomIndex(lineageNames)];

        RandomNames.NameEntry selectedGivenName =
            givenNames[Randoms.RandomIndex(givenNames)];

        characterData.lineageNameId = selectedLineage.id;
        characterData.lineageName = selectedLineage.ko;
        characterData.givenName = selectedGivenName.ko;

        int familyNumber = Randoms.RandomInt(1, 5);

        characterData.familyAffiliation =
            $"{selectedLineage.id}_{familyNumber:D3}";
    }

    /// <summary>
    /// 등급 및 기본 직업 설정
    /// </summary>
    private void CreateGradeAndJob(
        CharacterData characterData,
        JobStats baseJob)
    {
        characterData.grade = Randoms.RollGrade();
        characterData.jobType = baseJob.jobType;
    }

    /// <summary>
    /// 머리, 초상화, 상의, 하의 외형 데이터 생성
    /// </summary>
    private void CreateAppearance(
        CharacterData characterData,
        JobStats appearanceJob)
    {
        if (appearanceJob == null)
            return;

        Debug.Log(appearanceJob.jobType + "입니다");
        Debug.Log(appearanceJob.name + "입니다");
        // 머리와 초상화
        if (appearanceJob.heads != null &&
            appearanceJob.heads.Length > 0)
        {
            HeadData selectedHead =
                appearanceJob.heads[
                    Randoms.RandomIndex(appearanceJob.heads)];

            if (selectedHead != null)
            {
                characterData.head = selectedHead.headPrefab;
                characterData.portraits = selectedHead.portraits;

                if (selectedHead.portraits != null &&
                    selectedHead.portraits.Length > 0)
                {
                    characterData.portrait =
                        selectedHead.portraits[
                            Randoms.RandomIndex(selectedHead.portraits)];
                }
            }
        }

        // 상의
        if (appearanceJob.bodyPrefab != null &&
            appearanceJob.bodyPrefab.Length > 0)
        {
            characterData.top =
                appearanceJob.bodyPrefab[
                    Randoms.RandomIndex(appearanceJob.bodyPrefab)];
        }

        // 하의
        if (appearanceJob.legPrefab != null &&
            appearanceJob.legPrefab.Length > 0)
        {
            characterData.bottom =
                appearanceJob.legPrefab[
                    Randoms.RandomIndex(appearanceJob.legPrefab)];
        }
    }

    /// <summary>
    /// 등급별 기본 스탯 생성
    /// </summary>
    private void CreateStats(
        CharacterData characterData,
        JobStats baseJob)
    {
        characterData.hp = Randoms.RandomInt(
            baseJob.hp.GetRange(characterData.grade).x,
            baseJob.hp.GetRange(characterData.grade).y);

        characterData.mp = Randoms.RandomInt(
            baseJob.mp.GetRange(characterData.grade).x,
            baseJob.mp.GetRange(characterData.grade).y);

        characterData.str = Randoms.RandomInt(
            baseJob.str.GetRange(characterData.grade).x,
            baseJob.str.GetRange(characterData.grade).y);

        characterData.agi = Randoms.RandomInt(
            baseJob.agi.GetRange(characterData.grade).x,
            baseJob.agi.GetRange(characterData.grade).y);

        characterData.intel = Randoms.RandomInt(
            baseJob.intel.GetRange(characterData.grade).x,
            baseJob.intel.GetRange(characterData.grade).y);

        characterData.wis = Randoms.RandomInt(
            baseJob.wis.GetRange(characterData.grade).x,
            baseJob.wis.GetRange(characterData.grade).y);

        characterData.cha = Randoms.RandomInt(
            baseJob.cha.GetRange(characterData.grade).x,
            baseJob.cha.GetRange(characterData.grade).y);
    }

    /// <summary>
    /// 성격 데이터 선택
    /// </summary>
    private void CreatePersonality(CharacterData characterData)
    {
        if (personalityDatabase == null ||
            personalityDatabase.Personalities == null ||
            personalityDatabase.Personalities.Length == 0)
        {
            return;
        }

        CharacterPersonalityData[] personalities =
            personalityDatabase.Personalities;

        characterData.personalityData =
            personalities[Randoms.RandomIndex(personalities)];
    }

    /// <summary>
    /// 기본 행동 데이터 등록
    /// </summary>
    private void CreateActions(CharacterData characterData)
    {
        Dictionary<CharacterActionType, ICharacterAction> actions =
            actionManager.GetDefaultActions();

        if (actions == null)
            return;

        foreach (KeyValuePair<CharacterActionType, ICharacterAction> action
                 in actions)
        {
            characterData.AddAction(action.Key, action.Value);
        }
    }
}