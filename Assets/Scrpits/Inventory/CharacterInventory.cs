using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class CharacterInventory : MonoBehaviour
{
    [SerializeField] private int baseSlot = 5;
    [SerializeField] private int addSlot;

    // 총 가방 크기
    public int MaxSlot { get; private set; }

    // 캐릭터 보관
    [SerializeField] private List<Character> characters = new List<Character>();

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

    public bool IsFullLocked()
    {
        return characters.Count >= MaxSlot;
    }

    public void AddCharacter(Character character)
    {
        if (character == null)
        {
            Debug.LogError("캐릭터 null");
            return;
        }

        if (IsFullLocked())
            return;

        characters.Add(character);
    }

    public void AddSlot(int amount)
    {
        addSlot += amount;
        UpdateMaxSlot();
    }
}
