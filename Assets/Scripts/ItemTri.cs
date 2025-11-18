using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemTri : MonoBehaviour
{

    [Header("아이템 먹을 때 효과")]
    [SerializeField] private GameObject collectEffectPrefab;     // 파티클 이펙트 프리팹
    [SerializeField] private AudioClip collectSoundClip;       // 먹는 소리

    

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // 사라질 때 점수 올리기
            GameManager.Instance.IncreaseItemByFolder(transform.parent);

            if (collectEffectPrefab != null)
            {
                Instantiate(collectEffectPrefab, transform.position, Quaternion.identity);
            }


            if (collectSoundClip != null)
            {
                AudioSource.PlayClipAtPoint(collectSoundClip, transform.position);
            }
            // 자기 부모가 풀 폴더니까, 그냥 다시 부모로 돌려보내고 끄기
            transform.SetParent(transform.parent);  // 현재 부모로!
            gameObject.SetActive(false);
        }
    }

    // 자동으로 Trigger 켜기
    private void Reset()
    {
        if (TryGetComponent<Collider>(out var col))
            col.isTrigger = true;
    }
}
