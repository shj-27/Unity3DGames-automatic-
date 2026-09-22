using System.Collections.Generic;
using UnityEngine;

public class CharacterPool : MonoBehaviour
{
    private Queue<GameObject> pool = new Queue<GameObject>();

    [SerializeField] private GameObject characterPrefab;
    [SerializeField] private Transform root; // Characters 오브젝트

    public GameObject Get()
    {
        GameObject obj;

        // 1. 풀에 있으면 꺼내기
        if (pool.Count > 0)
        {
            obj = pool.Dequeue();
            
        }
        // 2. 없으면 생성
        else
        {
            obj = Instantiate(characterPrefab, root);
        }

        obj.SetActive(true);
        return obj;
    }

    // 반환 (끄고 넣음)
    public void Return(GameObject obj)
    {
        obj.SetActive(false);
        obj.transform.SetParent(root);
        pool.Enqueue(obj);
    }

    // 현재 풀 상태 확인용 (디버그용)
    public int PoolCount => pool.Count;
}