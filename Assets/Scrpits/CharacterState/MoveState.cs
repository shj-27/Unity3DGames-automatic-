using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveState : ICharacterState
{
    private Characters character;

    public MoveState(Characters character)
    {
        this.character = character;
    }

    public void Enter() { }
    public void Update() { }
    public void Exit() { }
}
