using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    // 싱글톤 인스턴스
    public static UIManager Instance { get; private set; }

    [SerializeField] private GameObject inventoryWindow;

    // 캐릭터 인벤토리 UI 참조
    [SerializeField] private CharacterInventoryUI characterInventoryUI;

    // 가방 버튼 참조
    [SerializeField] private Button[] topopenButtons;
    [SerializeField] private Button[] closeButtons;
    [SerializeField] private GameObject[] tabUIs;


    private void Awake()
    {
        // 이미 UIManager가 존재하면 중복 생성 방지
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        // 싱글톤 등록
        Instance = this;
    }

    private void Start()
    {
        inventoryWindow.SetActive(false);
        RegisterButtons();
        
    }

    void RegisterButtons()
    {
        OpenTabWindow();
        RegisterCloseButtons();
    }

    /// <summary>
    /// 인벤토리 UI를 최신 데이터로 갱신
    /// </summary>
    public void RefreshCharacterInventory(CharacterInventory inventory)
    {
        // UI가 연결되지 않았으면 종료
        if (characterInventoryUI == null) return;

        // 인벤토리 데이터 갱신
        characterInventoryUI.Refresh(inventory);
    }

    public void OpenTabWindow()
    {
        topopenButtons[0].onClick.AddListener(() => OpenTab(0));
        topopenButtons[1].onClick.AddListener(() => OpenTab(1));
        topopenButtons[2].onClick.AddListener(() => OpenTab(2));
    }

    public void OpenTab(int index)
    {
        inventoryWindow.SetActive(true);
        for (int i = 0; i < tabUIs.Length; i++)
        {
            tabUIs[i].SetActive(i == index);
        }

        Debug.Log($"탭 변경 : {index}");
    }

    public void RegisterCloseButtons()
    {
        for (int i = 0; i < closeButtons.Length; i++)
        {
            closeButtons[i].onClick.AddListener(CloseInventory);
        }
    }

    public void CloseInventory()
    {
        inventoryWindow.SetActive(false);
    }
}