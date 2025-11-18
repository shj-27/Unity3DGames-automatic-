using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;
using static UnityEditor.Progress;

public class SpawnPoint : MonoBehaviour
{

    [Header("스폰 설정")]
    [SerializeField] private Transform spawnPoint;           // 스폰 중심점
    [SerializeField] private float groundCheckDistance = 0.5f;  // 지면 체크 거리 땅이 아닌 곳에는 스폰되면 안되
    [SerializeField] private Transform groundParent;        // 스폰 구역


    [Header("아이템")]
    [SerializeField] public ItemObject[] itemObjects;       // 스폰할 아이템들
    private GameObject pool;



    [Header("스폰 제어")]
    [SerializeField] private bool autoSpawnOnStart = true;    //
    [SerializeField] private float spawnDelay = 2f;           //스폰 딜레이
    // Start is called before the first frame update
    void Start()
    {
        ItemSpawnProduction();
        if (autoSpawnOnStart) ReadSpawn();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void ItemSpawnProduction()    //아이템생산
    {
        if (itemObjects == null || itemObjects.Length == 0) return;  //아이템 0개면 그냥 가고 없다면

        foreach (ItemObject item in itemObjects)        //그 수 만큼
        {
            if (item.prefabs == null) continue;
            GameObject folder = item.prefabsBox;
            if (folder == null)
            {
                folder = new GameObject(item.itemName);  // 빈오브젝트 ItemObject스크립트의 저장된 이름을 가진 상태로 생성!
                folder.transform.SetParent(spawnPoint);  //spawnPoint부모로 들어감
                item.prefabsBox = folder;  // 다음부터는 재사용되게 저장
            }

            for (int i = 0; i < item.itemCount; i++)     //ItemObject스크립트의 개수 만큼
            {
                pool = Instantiate(item.prefabs, spawnPoint.position, Quaternion.identity);        //생산해라
                pool.SetActive(false);                  //일단 생산한 모든 것들을 안보이게 하고
                pool.transform.SetParent(folder.transform);  // 정리해서 부모 아래로
                pool.name = item.itemName + "_" + i;        // 이름 구분 (선택)

            }
        }

    }

    public void ReadSpawn()
    {
        StopAllCoroutines();
        StartCoroutine(SpawnRoutine());
    }

    public GameObject GetItemFromPool(ItemObject item)
    {
        if (item.prefabsBox == null) return null;

        foreach (Transform child in item.prefabsBox.transform)
        {
            if (!child.gameObject.activeSelf) // 비활성화된 거 찾기
            {
                return child.gameObject;
            }
        }
        return null; // 다 사용 중이면 null
    }

    IEnumerator SpawnRoutine()
    {
        while (true)
        {
            ItemObject item = itemObjects[Random.Range(0, itemObjects.Length)];
            GameObject obj = GetItemFromPool(item);
            if (obj != null)
            {
                Vector3 spawnPos;

                if (groundParent.childCount > 0)
                {
                    // 랜덤한 땅 오브젝트 선택
                    Transform randomGround = groundParent.GetChild(Random.Range(0, groundParent.childCount));

                    // ← 여기만 바꿨음! 진짜 랜덤 위치로!
                    spawnPos = GetRandomPositionOnGround(randomGround);
                }
                else
                {
                    spawnPos = spawnPoint.position + Vector3.up * 0.5f;
                }

                obj.transform.position = spawnPos;
                obj.SetActive(true);
            }

            yield return new WaitForSeconds(spawnDelay);
        }
    }

    private Vector3 GetRandomPositionOnGround(Transform ground)
    {
        // 1. Collider 있으면 그 범위 안에서 랜덤
        if (ground.TryGetComponent<Collider>(out var col))
        {
            Bounds bounds = col.bounds;
            return new Vector3(
                Random.Range(bounds.min.x, bounds.max.x),
                bounds.max.y + 0.5f,
                Random.Range(bounds.min.z, bounds.max.z)
            );
        }

        // 2. Renderer 있으면 그 범위 사용
        if (ground.TryGetComponent<Renderer>(out var ren))
        {
            Bounds bounds = ren.bounds;
            return new Vector3(
                Random.Range(bounds.min.x, bounds.max.x),
                bounds.max.y + 0.5f,
                Random.Range(bounds.min.z, bounds.max.z)
            );
        }

        // 3. 둘 다 없으면 중심에
        return ground.position + Vector3.up * 0.5f;
    }

}
