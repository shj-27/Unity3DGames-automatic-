using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GatherState : ICharacterState
{
    private Actions character;

    public GatherState(Actions character)
    {
        this.character = character;
    }


    public void Enter() { }
    public void Update() { }
    public void FixedUpdate() { }
    public void LateUpdate() { }
    public void Exit() { }
}
