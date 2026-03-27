using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CharacterStateMachine 
{
    private Dictionary<CharacterStateType, ICharacterState> states
        = new Dictionary<CharacterStateType, ICharacterState>();

    public ICharacterState CurrentState { get; private set; }

    // 상태 등록
    public void RegisterState(CharacterStateType type, ICharacterState state)
    {
        states[type] = state;
    }

    // enum으로 상태 변경
    public void ChangeState(CharacterStateType type)
    {
        if (CurrentState != null)
            CurrentState.Exit();

        CurrentState = states[type];
        CurrentState.Enter();
    }

    public void Update()
    {
        CurrentState?.Update();
    }
}

public class Characters : MonoBehaviour
{
    private CharacterStateMachine stateMachine;

    private void Awake()
    {
        stateMachine = new CharacterStateMachine();

        stateMachine.RegisterState(CharacterStateType.Idle, new IdleState(this));
        stateMachine.RegisterState(CharacterStateType.Move, new MoveState(this));
        stateMachine.RegisterState(CharacterStateType.Attack, new AttackState(this));
        stateMachine.RegisterState(CharacterStateType.Gather, new GatherState(this));

        stateMachine.ChangeState(CharacterStateType.Idle);
    }

    private void Update()
    {
        stateMachine.Update();
    }
}
