using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemTri : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // 자기 부모가 풀 폴더니까, 그냥 다시 부모로 돌려보내고 끄기 → 끝!
            transform.SetParent(transform.parent);  // 현재 부모가 풀 폴더임
            gameObject.SetActive(false);
        }
    }

    // 에디터에서 붙이면 자동으로 Trigger 켜기
    private void Reset()
    {
        if (TryGetComponent<Collider>(out var col))
            col.isTrigger = true;
    }
}
