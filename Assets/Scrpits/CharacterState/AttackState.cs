using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : ICharacterState
{
    private Characters character;

    public AttackState(Characters character)
    {
        this.character = character;
    }

    public void Enter() { }
    public void Update() { }
    public void Exit() { }
}
