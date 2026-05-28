using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : MonoBehaviour
{
    public static CharacterManager Instance { get; private set; }

    [SerializeField] private CharacterFactory factory;
    [SerializeField] private CharacterInventory inventory;
    public CharacterInventory Inventory => inventory;
    [SerializeField] private CharacterSpawner spawner;
    [SerializeField] private CharacterPool pool;
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

    void Start()
    {
        if (inventory == null || factory == null || autos == null || execution == null)
        {
            Debug.LogError("참조 없음");
            return;
        }

        StartCoroutine(autos.AutoSpawn(
            interval,
            inventory.Data.MaxAutoCreateCount,
            () => inventory.Count,
            TryAutoCreate
        ));
    }

    void TryAutoCreate()
    {
        // 상태 판단은 Manager가 함
        if (inventory.IsFull())
            return;

        // 실행은 Execution에게 넘김
        execution.TryAddCharacter(factory, inventory);

        CharacterData data = inventory.Characters[inventory.Count - 1];
        if (data == null)
        {
            Debug.LogError("data가 null임");
            return;
        }
        spawner.Spawn(data);
    }

    
}
