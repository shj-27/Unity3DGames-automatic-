using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] private string id;

    private bool isInitialized = false;


    // 캐릭터 전체 데이터
    private CharacterCreateData characterCreateData;


    // 외부에서 읽기만 가능
    public string ID => id;



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
            GameObject headObject =
                Instantiate(data.head, headSocket);

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
            GameObject bodyObject =
                Instantiate(data.top, bodySocket);

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
            GameObject legObject =
                Instantiate(data.bottom, legSocket);

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



        // 외형 생성
        RefreshAppearance();


        isInitialized = true;
    }


   
    public void CallCharacterManager()
    {
        CharacterManager.Instance.ReceiveCharacter(this);
    }

    
}