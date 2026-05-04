using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : ICharacterState
{
    private Actions character;

    public IdleState(Actions character)
    {
        this.character = character;
    }


    public void Enter() { }
    public void Update() { }
    public void FixedUpdate() { }
    public void LateUpdate() { }
    public void Exit() { }


}
