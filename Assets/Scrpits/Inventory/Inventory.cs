using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] private int baseSlot = 5;

    [SerializeField] private int addSlot;

    public int MaxSlot
    {
        get
        {
            return baseSlot + addSlot;
        }
    }
}
