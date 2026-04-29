using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterInventory : MonoBehaviour
{
    [SerializeField] private int baseSlot = 5;
    [SerializeField] private int addSlot;

    // 총 가방 크기
    public int MaxSlot { get; private set; }

    // 현재 개수
    private int currentCharacterCount = 0;

    void Start()
    {
        UpdateMaxSlot();
    }

    void UpdateMaxSlot()
    {
        MaxSlot =
            baseSlot +
            addSlot;
    }

    public int GetCurrentCount()
    {
        return currentCharacterCount;
    }

    public bool IsFullLocked()
    {
        return currentCharacterCount >= MaxSlot;
    }

    public void AddCharacter()
    {
        if (IsFullLocked())
            return;

        currentCharacterCount++;
    }

    public void RemoveCharacter()
    {
        if (currentCharacterCount > 0)
        {
            currentCharacterCount--;
        }
    }

    public void AddSlot(int amount)
    {
        addSlot += amount;

        UpdateMaxSlot();
    }
}
