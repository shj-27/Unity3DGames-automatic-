using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//캐릭터의 정보를 만드는 장소
//애는 캐릭터 제작이지 캐릭터 선언이 아니다 즉 캐릭터의 능력치들은 애가 만들고 캐릭터 선언 되는 놈에게 정보를 주는 놈이다
public class CharacterFactory : MonoBehaviour
{

    [SerializeField] private List<JobStats> jobStatsList;
    [SerializeField] private GameObject characterPrefab;

    [SerializeField] private TypeData characterTypeData;
    private int currentId = 10001;
    // None 직업 가져오기
    public JobStats GetDefaultJob()
    {


        return jobStatsList.Find(j => j.jobType == JobType.None);
    }

    // 데이터 생성
    public CharacterData CreateCharacterData()
    {
        JobStats baseJob = GetDefaultJob();
        if (baseJob == null)
        {
            Debug.LogError("None JobStats 없음");
            return null;
        }
        Grade grade = Randoms.RollGrade();

        CharacterData data = new CharacterData();

        data.id = $"{characterTypeData.prefix}{currentId++}";
        if (characterTypeData == null)
        {
            Debug.LogError("TypeData 연결 안됨");
            return null;
        }
        data.jobType = baseJob.jobType;
        data.grade = grade;

        data.hp = Randoms.RandomInt(baseJob.hp.GetRange(grade).x, baseJob.hp.GetRange(grade).y);
        data.mp = Randoms.RandomInt(baseJob.mp.GetRange(grade).x, baseJob.mp.GetRange(grade).y);

        data.str = Randoms.RandomInt(baseJob.str.GetRange(grade).x, baseJob.str.GetRange(grade).y);
        data.agi = Randoms.RandomInt(baseJob.agi.GetRange(grade).x, baseJob.agi.GetRange(grade).y);

        data.intel = Randoms.RandomInt(baseJob.intel.GetRange(grade).x, baseJob.intel.GetRange(grade).y);
        data.wis = Randoms.RandomInt(baseJob.wis.GetRange(grade).x, baseJob.wis.GetRange(grade).y);
        data.cha = Randoms.RandomInt(baseJob.cha.GetRange(grade).x, baseJob.cha.GetRange(grade).y);

        return data;
    }

    // 캐릭터 생성 (생산만)
    public void ApplyData(Character character)
    {
        if (character == null)
        {
            Debug.LogError("Character 없음");
            return;
        }

        CharacterData data = CreateCharacterData();
        if (data == null)
            return;

        character.SetData(data);
    }

}
