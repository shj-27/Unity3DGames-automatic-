using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSlotButton : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] private Button button;
    [SerializeField] private Image icon;

    private CharacterData data;

    public void SetData(CharacterData characterData)
    {
        data = characterData;

        if (data == null)
        {
            icon.sprite = null;
            return;
        }

        icon.sprite = data.portrait;
        icon.enabled = (icon.sprite != null);
    }

    // 클릭 시 실행
    private void OnClick()
    {
        //UIManager.Instance.OpenCharacterDetail(data);
    }
}
