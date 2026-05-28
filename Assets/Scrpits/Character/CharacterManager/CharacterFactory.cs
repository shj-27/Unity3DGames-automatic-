using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//캐릭터의 정보를 만드는 장소
//애는 캐릭터 제작이지 캐릭터 선언이 아니다 즉 캐릭터의 능력치들은 애가 만들고 캐릭터 선언 되는 놈에게 정보를 주는 놈이다
// 캐릭터 데이터 생성 전용
// 생성(Instantiate) 안 함
// 배치 안 함
public class CharacterFactory : MonoBehaviour
{
    [SerializeField] private List<JobStats> jobStatsList;
    [SerializeField] private TypeData characterTypeData;

    private int currentId = 10001;

    // None 직업 가져오기
    public JobStats GetDefaultJob()
    {
        return jobStatsList.Find(j => j.jobType == JobType.None);
    }

    // 캐릭터 데이터 생성
    public CharacterData CreateCharacterData()
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

        Grade grade = Randoms.RollGrade();

        CharacterData data = new CharacterData();

        // ID 생성
        data.id = $"{characterTypeData.prefix}{currentId++}";

        // 기본 정보
        data.jobType = baseJob.jobType;
        data.grade = grade;

        // 외형
        data.head = GetRandomHead(baseJob);
        data.top = GetRandomBody(baseJob);
        data.bottom = GetRandomLeg(baseJob);


        // 능력치
        data.hp = Randoms.RandomInt(baseJob.hp.GetRange(grade).x, baseJob.hp.GetRange(grade).y);
        data.mp = Randoms.RandomInt(baseJob.mp.GetRange(grade).x, baseJob.mp.GetRange(grade).y);

        data.str = Randoms.RandomInt(baseJob.str.GetRange(grade).x, baseJob.str.GetRange(grade).y);
        data.agi = Randoms.RandomInt(baseJob.agi.GetRange(grade).x, baseJob.agi.GetRange(grade).y);

        data.intel = Randoms.RandomInt(baseJob.intel.GetRange(grade).x, baseJob.intel.GetRange(grade).y);
        data.wis = Randoms.RandomInt(baseJob.wis.GetRange(grade).x, baseJob.wis.GetRange(grade).y);
        data.cha = Randoms.RandomInt(baseJob.cha.GetRange(grade).x, baseJob.cha.GetRange(grade).y);

        return data;
    }

    // 외형 랜덤 선택


    private GameObject GetRandomHead(JobStats jobStats)
    {
        if (jobStats.headPrefab == null || jobStats.headPrefab.Length == 0)
            return null;

        return jobStats.headPrefab[Random.Range(0, jobStats.headPrefab.Length)];
    }

    private GameObject GetRandomBody(JobStats jobStats)
    {
        if (jobStats.bodyPrefab == null || jobStats.bodyPrefab.Length == 0)
            return null;

        return jobStats.bodyPrefab[Random.Range(0, jobStats.bodyPrefab.Length)];
    }

    private GameObject GetRandomLeg(JobStats jobStats)
    {
        if (jobStats.legPrefab == null || jobStats.legPrefab.Length == 0)
            return null;

        return jobStats.legPrefab[Random.Range(0, jobStats.legPrefab.Length)];
    }

}
