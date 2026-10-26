using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CharacterEnumList;
public class CharacterPart : MonoBehaviour
{

    [SerializeField] private PartType partType;

    private Character owner;

    public Character Owner => owner;

    public void Initialize(Character character)
    {
        owner = character;
    }
}
