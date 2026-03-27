using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : ICharacterState
{
    private Characters character;

    public IdleState(Characters character)
    {
        this.character = character;
    }

    public void Enter() { }
    public void Update() { }
    public void Exit() { }
}
