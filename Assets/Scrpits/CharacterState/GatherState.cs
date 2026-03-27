using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GatherState : ICharacterState
{
    private Characters character;

    public GatherState(Characters character)
    {
        this.character = character;
    }

    public void Enter() { }
    public void Update() { }
    public void Exit() { }
}
