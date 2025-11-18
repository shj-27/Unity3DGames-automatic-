using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    [SerializeField] private TextMeshProUGUI[] Items;
    [SerializeField] private int[] maxCount; // 최대 몇개까지 모아야되는지 나타내는 수
    [SerializeField] private int count;
    private int[] currentCounts;           //개수 담는 배열

    [SerializeField] private SpawnPoint spawnPoint;

    [Header("클리어")]
    [SerializeField] private GameObject gamePanel;
    [SerializeField] private Button quitButton;               // 나가기 버튼
    [SerializeField] private Button restartButton;            // 다시하기 버튼
    private bool isCleared = false;
    private void Awake()
    {
        Instance = this;

        currentCounts = new int[Items.Length];
        maxCount = new int[Items.Length];
       
        StartText();
    }


    // Start is called before the first frame update1
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void StartText()
    {
        if (Items == null || Items.Length == 0) return;

        for (int i = 0; i < Items.Length; i++)
        {
            currentCounts[i] = 0;
            maxCount[i] = Random.Range(3, 11);

            Items[i].text = count + "/" + maxCount[i];
        }

        gamePanel.SetActive(false);
        if (quitButton) quitButton.onClick.AddListener(QuitGame);
        if (restartButton) restartButton.onClick.AddListener(RestartGame);
    }
    public void IncreaseItemByFolder(Transform folder)
    {
        if (spawnPoint == null || folder == null) return;

        for (int i = 0; i < spawnPoint.itemObjects.Length; i++)
        {
            if (spawnPoint.itemObjects[i].prefabsBox == folder.gameObject)
            {
                IncreaseItem(i);
                return;
            }
        }
    }
    public void IncreaseItem(int slotIndex)//가지고 있는 아이템의 해당 배열
    {
        if (slotIndex < 0 || slotIndex >= Items.Length) return;

        if (currentCounts[slotIndex] >= maxCount[slotIndex]) return;

        currentCounts[slotIndex]++; //아이템 0번 배열은 currentCounts배열의 0번 개수
        count = currentCounts[slotIndex];
        Items[slotIndex].text = count + "/" + maxCount[slotIndex];

        CheckClear();
    }

    void CheckClear()
    {
        for (int i = 0; i < currentCounts.Length; i++)
        {
            if (currentCounts[i] < maxCount[i])
                return;  // 하나라도 덜 모았으면 리턴
        }

        // 여기 오면 전부 다 모은 것!
        if (!isCleared)
        {
            
            ShowClearPanel();
        }
    }

    void ShowClearPanel()
    {
        gamePanel.SetActive(true);
        isCleared = true;
        // 시간 멈추기 (선택)
        Time.timeScale = 0f;
    }

    public void QuitGame()
    {
        Time.timeScale = 1f;
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        CharacterControllers player = FindObjectOfType<CharacterControllers>();
        if (player != null)
            player.ResetToStartPosition();
        SceneManager.LoadScene("SampleScene");
    }
}
