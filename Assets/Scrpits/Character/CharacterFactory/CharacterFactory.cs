
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 캐릭터 생성 전용 Factory
///
/// 역할:
/// - 캐릭터 데이터 생성
/// - 장비 데이터 생성
/// - 개인 인벤토리 데이터 생성
/// - 캐릭터가 사용할 기본 행동 데이터 구성
///
/// 주의:
/// - 캐릭터 오브젝트 생성(Instantiate) 안 함
/// - 캐릭터 배치 안 함
/// - 캐릭터의 실제 행동 관리 안 함
///
/// 생성된 데이터는 Character에게 전달됨
/// </summary>
public class CharacterFactory : MonoBehaviour
{
    [SerializeField] private List<JobStats> jobStatsList;
    [SerializeField] private TypeData characterTypeData;

    // 캐릭터 성격 데이터베이스
    [SerializeField] private CharacterPersonalityDatabase personalityDatabase;

    // 기본 행동을 등록하고 관리하는 Manager
    [SerializeField] private CharacterActionManager actionManager;

    // 캐릭터 성씨와 이름을 생성하는 클래스
    [SerializeField] private RandomNames randomNames;

    private int currentId = 10001;

    /// <summary>
    /// 기본 직업(None) 데이터 가져오기
    /// 캐릭터 생성 시 기본 능력치 기준으로 사용
    /// </summary>
    private JobStats GetDefaultJob()
    {
        return jobStatsList.Find(j => j.jobType == JobType.None);
    }

    /// <summary>
    /// 캐릭터 전체 데이터 생성
    /// </summary>
    public CharacterCreateData CreateCharacter()
    {
        JobStats baseJob = GetDefaultJob();

        if (baseJob == null)
        {
            Debug.LogError("None JobStats 없음");
            return null;
        }

        if (characterTypeData == null)
        {
            Debug.LogError("TypeData 연결 안됨");
            return null;
        }

        if (actionManager == null)
        {
            Debug.LogError("CharacterActionManager 연결 안됨");
            return null;
        }

        // 캐릭터 생성 결과 데이터
        CharacterCreateData result = new CharacterCreateData();

        // 캐릭터 기본 데이터
        CharacterData characterData = new CharacterData();

        // -----------------------------
        // 캐릭터 성씨와 이름 생성
        // -----------------------------

        // 성씨와 이름 배열에서 무작위 인덱스를 선택한다.
        if (randomNames != null)
        {
            RandomNames.NameEntry[] lineageNames =
                randomNames.LineageNames;

            RandomNames.NameEntry[] givenNames =
                randomNames.GivenNames;

            if (lineageNames != null &&
                lineageNames.Length > 0 &&
                givenNames != null &&
                givenNames.Length > 0)
            {
                // 성씨 배열에서 무작위 선택
                int lineageIndex =
                    Randoms.RandomIndex(lineageNames);

                // 이름 배열에서 무작위 선택
                int givenNameIndex =
                    Randoms.RandomIndex(givenNames);

                // 선택한 성씨와 이름을 각각 저장
                characterData.lineageName =
                    lineageNames[lineageIndex].ko;

                characterData.givenName =
                    givenNames[givenNameIndex].ko;
            }
        }

        // -----------------------------
        // 성격 데이터 생성
        // -----------------------------

        if (personalityDatabase != null &&
            personalityDatabase.Personalities != null &&
            personalityDatabase.Personalities.Length > 0)
        {
            CharacterPersonalityData[] personalities =
                personalityDatabase.Personalities;

            // 성격 배열에서 무작위 인덱스를 선택한다.
            int personalityIndex =
                Randoms.RandomIndex(personalities);

            characterData.personalityData =
                personalities[personalityIndex];
        }
        else
        {
            Debug.LogError("CharacterPersonalityDatabase가 연결되지 않았거나 성격 데이터가 비어 있음");
        }

        // -----------------------------
        // 기본 행동 데이터 구성
        // -----------------------------

        // CharacterActionManager에 등록된 기본 행동 가져오기
        Dictionary<CharacterActionType, ICharacterAction> actions =
            actionManager.GetDefaultActions();

        // 기본 행동을 현재 캐릭터 데이터에 등록
        foreach (
            KeyValuePair<CharacterActionType, ICharacterAction> action
            in actions)
        {
            characterData.AddAction(action.Key, action.Value);
        }

        // -----------------------------
        // ID 생성
        // -----------------------------

        characterData.id =
            $"{characterTypeData.prefix}{currentId++}";

        // -----------------------------
        // 등급 및 직업 설정
        // -----------------------------

        Grade grade = Randoms.RollGrade();

        characterData.grade = grade;
        characterData.jobType = baseJob.jobType;

        // -----------------------------
        // 외형 데이터 생성
        // -----------------------------

        HeadData selectedHead = GetRandomHead(baseJob);

        if (selectedHead != null)
        {
            // 머리 외형
            characterData.head = selectedHead.headPrefab;

            // 해당 머리의 전체 초상화 저장
            characterData.portraits = selectedHead.portraits;

            // 초상화 배열에서 무작위 선택
            if (selectedHead.portraits != null &&
                selectedHead.portraits.Length > 0)
            {
                int portraitIndex =
                    Randoms.RandomIndex(selectedHead.portraits);

                characterData.portrait =
                    selectedHead.portraits[portraitIndex];
            }
        }

        // 상의 랜덤 선택
        characterData.top = GetRandomBody(baseJob);

        // 하의 랜덤 선택
        characterData.bottom = GetRandomLeg(baseJob);

        // -----------------------------
        // 기본 능력치 생성
        // -----------------------------

        characterData.hp =
            Randoms.RandomInt(
                baseJob.hp.GetRange(grade).x,
                baseJob.hp.GetRange(grade).y
            );

        characterData.mp =
            Randoms.RandomInt(
                baseJob.mp.GetRange(grade).x,
                baseJob.mp.GetRange(grade).y
            );

        characterData.str =
            Randoms.RandomInt(
                baseJob.str.GetRange(grade).x,
                baseJob.str.GetRange(grade).y
            );

        characterData.agi =
            Randoms.RandomInt(
                baseJob.agi.GetRange(grade).x,
                baseJob.agi.GetRange(grade).y
            );

        characterData.intel =
            Randoms.RandomInt(
                baseJob.intel.GetRange(grade).x,
                baseJob.intel.GetRange(grade).y
            );

        characterData.wis =
            Randoms.RandomInt(
                baseJob.wis.GetRange(grade).x,
                baseJob.wis.GetRange(grade).y
            );

        characterData.cha =
            Randoms.RandomInt(
                baseJob.cha.GetRange(grade).x,
                baseJob.cha.GetRange(grade).y
            );

        // -----------------------------
        // 장비 데이터 생성
        // -----------------------------

        // 처음 생성 시 장비 없음
        CharacterEquipmentData equipmentData =
            new CharacterEquipmentData();

        // -----------------------------
        // 개인 소지품 데이터 생성
        // -----------------------------

        // 처음 생성 시 빈 가방
        CharacterPersonalInventoryData inventoryData =
            new CharacterPersonalInventoryData();

        // -----------------------------
        // 결과 저장
        // -----------------------------

        result.characterData = characterData;
        result.equipmentData = equipmentData;
        result.inventoryData = inventoryData;

        return result;
    }

    // -----------------------------
    // 외형 랜덤 선택
    // -----------------------------

    /// <summary>
    /// JobStats에 등록된 머리 중 하나를 랜덤으로 선택
    /// </summary>
    private HeadData GetRandomHead(JobStats jobStats)
    {
        if (jobStats.heads == null ||
            jobStats.heads.Length == 0)
            return null;

        int index = Randoms.RandomIndex(jobStats.heads);

        return jobStats.heads[index];
    }

    /// <summary>
    /// JobStats에 등록된 상의 중 하나를 랜덤으로 선택
    /// </summary>
    private GameObject GetRandomBody(JobStats jobStats)
    {
        if (jobStats.bodyPrefab == null ||
            jobStats.bodyPrefab.Length == 0)
            return null;

        int index = Randoms.RandomIndex(jobStats.bodyPrefab);

        return jobStats.bodyPrefab[index];
    }

    /// <summary>
    /// JobStats에 등록된 하의 중 하나를 랜덤으로 선택
    /// </summary>
    private GameObject GetRandomLeg(JobStats jobStats)
    {
        if (jobStats.legPrefab == null ||
            jobStats.legPrefab.Length == 0)
            return null;

        int index = Randoms.RandomIndex(jobStats.legPrefab);

        return jobStats.legPrefab[index];
    }
}
