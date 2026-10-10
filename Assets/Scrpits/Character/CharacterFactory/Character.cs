using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] private string id;

    private bool isInitialized = false;
    private CharacterThought thought;

    // 캐릭터 전체 데이터
    private CharacterCreateData characterCreateData;


    // 외부에서 읽기만 가능
    public string ID => id;



    private void Awake()
    {
        
        thought = gameObject.AddComponent<CharacterThought>();

        Debug.Log(
            "CharacterThought 연결완료" +
            $"[Character] {gameObject.name} | " +
            $"CharacterThought 생성: {thought != null}"
        );
    }



    // 외형 위치
    [SerializeField] private Transform headSocket;
    [SerializeField] private Transform bodySocket;
    [SerializeField] private Transform legSocket;



    private CharacterPart headPart;
    private CharacterPart bodyPart;
    private CharacterPart legPart;



    /// <summary>
    /// ID는 생성 후 변경하지 않음
    /// </summary>
    public void SetID(string newId)
    {
        if (!string.IsNullOrEmpty(id))
            return;

        id = newId;
    }



    /// <summary>
    /// 외형 생성
    ///
    /// CharacterData의 외형 정보를 사용
    /// </summary>
    private void RefreshAppearance()
    {
        CharacterData data = characterCreateData.characterData;

        // 머리
        if (data.head != null)
        {
            Debug.Log($"[Character] 머리 생성 전 : {data.head.name}");

            GameObject headObject =
                Instantiate(data.head, headSocket);

            Debug.Log($"[Character] 머리 생성 후 : {headObject.name}");

            headPart =
                headObject.GetComponent<CharacterPart>();

            if (headPart != null)
            {
                headPart.Initialize(this);
            }
        }

        // 몸통
        if (data.top != null)
        {
            Debug.Log($"[Character] 몸통 생성 전 : {data.top.name}");

            GameObject bodyObject =
                Instantiate(data.top, bodySocket);

            Debug.Log($"[Character] 몸통 생성 후 : {bodyObject.name}");

            bodyPart =
                bodyObject.GetComponent<CharacterPart>();

            if (bodyPart != null)
            {
                bodyPart.Initialize(this);
            }
        }

        // 다리
        if (data.bottom != null)
        {
            Debug.Log($"[Character] 다리 생성 전 : {data.bottom.name}");

            GameObject legObject =
                Instantiate(data.bottom, legSocket);

            Debug.Log($"[Character] 다리 생성 후 : {legObject.name}");

            legPart =
                legObject.GetComponent<CharacterPart>();

            if (legPart != null)
            {
                legPart.Initialize(this);
            }
        }
    }



    private void Start()
    {
        CharacterInventory inventory =
       CharacterManager.Instance.Inventory;

        // ID로 캐릭터 전체 데이터 검색
        characterCreateData =
            inventory.GetCharacterByID(id);

        if (characterCreateData == null)
        {
            Debug.LogError($"캐릭터 데이터 없음 : {id}");
            return;
        }

        // Thought가 자신의 캐릭터를 확인
        thought.Identify();

        // 외형 생성
        RefreshAppearance();

        isInitialized = true;
    }



    public void CallCharacterManager()
    {
        CharacterManager.Instance.ReceiveCharacter(this);
    }

    // 이 Character가 사용할 공용 행동들
    private Dictionary<CharacterActionType, ICharacterAction> commonActions;

    public void SetCommonActions(
        Dictionary<CharacterActionType, ICharacterAction> actions)
    {
        commonActions = actions;

        Debug.Log(
            $"[Character] {gameObject.name} | " +
            $"공용 행동 등록: {commonActions != null} | " +
            $"행동 개수: {commonActions?.Count ?? 0}"
        );
    }

    public void AddCommonAction(
    CharacterActionType type,
    ICharacterAction action)
    {
        commonActions[type] = action;

        Debug.Log(
            $"[Character] {gameObject.name} | " +
            $"행동 부여 받음: {type} | " +
            $"Action: {action.GetType().Name}"
        );
    }
}