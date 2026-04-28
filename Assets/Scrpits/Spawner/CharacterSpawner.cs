using UnityEngine;
using UnityEngine.UI;

public class CharacterSpawner : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] private Button spawnButton;

    [Header("Spawn Setting")]
    [SerializeField] private GameObject spawnerPrefab;
    [SerializeField] private Transform spawnPoint;

    void Start()
    {
        // 버튼 클릭 이벤트 코드로 연결
        spawnButton.onClick.AddListener(CreateSpawner);
    }

    void CreateSpawner()
    {
        Instantiate(spawnerPrefab, spawnPoint.position, Quaternion.identity);
    }

    void OnDestroy()
    {
        spawnButton.onClick.RemoveListener(CreateSpawner);
    }
}
