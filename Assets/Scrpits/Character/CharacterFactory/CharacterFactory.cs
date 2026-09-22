using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 캐릭터 생성 전용 Factory
/// 
/// 역할:
/// - 캐릭터 데이터 생성
/// - 장비 데이터 생성
/// - 개인 인벤토리 데이터 생성
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
    /// 
    /// 생성 결과:
    /// - 캐릭터 기본 데이터
    /// - 장비 데이터
    /// - 개인 소지품 데이터
    /// 
    /// 반환 후 Character가 사용
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


        // 캐릭터 생성 결과 데이터
        CharacterCreateData result = new CharacterCreateData();


        // -----------------------------
        // 캐릭터 기본 데이터 생성
        // -----------------------------

        CharacterData characterData = new CharacterData();


        // ID 생성
        characterData.id =
            $"{characterTypeData.prefix}{currentId++}";


        // 등급 결정
        Grade grade = Randoms.RollGrade();

        characterData.grade = grade;
        characterData.jobType = baseJob.jobType;



        // -----------------------------
        // 외형 데이터 생성
        // -----------------------------

        HeadData selectedHead = GetRandomHead(baseJob);

        if (selectedHead != null)
        {
            characterData.head = selectedHead.headPrefab;
            characterData.portraits = selectedHead.portraits;


            if (selectedHead.portraits != null &&
                selectedHead.portraits.Length > 0)
            {
                characterData.portrait =
                    selectedHead.portraits[
                        Random.Range(0, selectedHead.portraits.Length)
                    ];
            }
        }


        characterData.top = GetRandomBody(baseJob);
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
        // 모든 슬롯 null 상태
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

    private HeadData GetRandomHead(JobStats jobStats)
    {
        if (jobStats.heads == null ||
            jobStats.heads.Length == 0)
            return null;


        return jobStats.heads[
            Random.Range(0, jobStats.heads.Length)
        ];
    }


    private GameObject GetRandomBody(JobStats jobStats)
    {
        if (jobStats.bodyPrefab == null ||
            jobStats.bodyPrefab.Length == 0)
            return null;


        return jobStats.bodyPrefab[
            Random.Range(0, jobStats.bodyPrefab.Length)
        ];
    }


    private GameObject GetRandomLeg(JobStats jobStats)
    {
        if (jobStats.legPrefab == null ||
            jobStats.legPrefab.Length == 0)
            return null;


        return jobStats.legPrefab[
            Random.Range(0, jobStats.legPrefab.Length)
        ];
    }
}