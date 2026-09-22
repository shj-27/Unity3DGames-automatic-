using System.Collections;
using UnityEngine;

public class CharacterManager : MonoBehaviour
{
    public static CharacterManager Instance { get; private set; }


    [Header("Character")]
    [SerializeField] private CharacterFactory factory;
    [SerializeField] private CharacterInventory inventory;

    public CharacterInventory Inventory => inventory;


    [Header("Spawn")]
    [SerializeField] private CharacterSpawner spawner;
    [SerializeField] private CharacterPool pool;


    [Header("Auto Create")]
    [SerializeField] private Autos autos;
    [SerializeField] private Execution execution;


    [SerializeField] private float interval = 1f;



    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }



    private void Start()
    {
        if (inventory == null ||
            factory == null ||
            autos == null ||
            execution == null)
        {
            Debug.LogError("참조 없음");
            return;
        }



        StartCoroutine(
            autos.AutoSpawn(
                interval,
                inventory.Data.MaxAutoCreateCount,
                () => inventory.Count,
                TryAutoCreate
            )
        );
    }



    /// <summary>
    /// 자동 캐릭터 생성
    ///
    /// Manager 역할:
    /// - 생성 조건 확인
    /// - Execution 호출
    /// - 생성된 캐릭터 Spawn 요청
    /// </summary>
    private void TryAutoCreate()
    {
        // 보관 공간 확인
        if (inventory.IsFull())
            return;



        // 캐릭터 전체 데이터 생성 및 등록
        execution.TryAddCharacter(factory, inventory);



        // 방금 추가된 캐릭터 데이터 가져오기
        CharacterCreateData createData =
            inventory.Characters[inventory.Count - 1];


        if (createData == null ||
            createData.characterData == null)
        {
            Debug.LogError("캐릭터 데이터가 없음");
            return;
        }



        // 실제 오브젝트 생성에는 기본 캐릭터 데이터만 전달
        spawner.Spawn(
            createData.characterData
        );
    }

    public void ReceiveCharacter(Character character)
    {
        string characterId = character.ID;

        CharacterCreateData data =
            inventory.GetCharacterByID(characterId);

        if (data == null)
        {
            Debug.Log($"가방에 없는 캐릭터: {characterId}");
            return;
        }

        Debug.Log($"가방에 있는 캐릭터 확인: {characterId}");
    }
}