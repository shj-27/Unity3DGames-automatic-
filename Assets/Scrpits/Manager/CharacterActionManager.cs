using System.Collections.Generic;
using UnityEngine;
using CharacterAction;
/// <summary>
/// 캐릭터 공용 행동 관리
///
/// 역할:
/// - 기본 행동 등록
/// - 등록된 기본 행동을 Factory에 전달
/// </summary>
public class CharacterActionManager : MonoBehaviour
{
    // 등록된 공용 행동
    private Dictionary<CharacterActionType, ICharacterAction> commonActions
        = new Dictionary<CharacterActionType, ICharacterAction>();


    private void Awake()
    {
        // 기본 행동 등록
        RegisterDefaultActions();

        Debug.Log(
            $"[CharacterActionManager] 공용 행동 등록 완료 | " +
            $"행동 개수: {commonActions.Count}"
        );
    }


    /// <summary>
    /// 기본 행동 등록
    /// </summary>
    private void RegisterDefaultActions()
    {
        RegisterCommonAction(
            CharacterActionType.Idle,
            new IdleAction()
        );

        RegisterCommonAction(
            CharacterActionType.Move,
            new MoveAction()
        );

        RegisterCommonAction(
            CharacterActionType.Attack,
            new AttackAction()
        );

        RegisterCommonAction(
            CharacterActionType.Gather,
            new GatherAction()
        );

        RegisterCommonAction(
            CharacterActionType.Craft,
            new CraftAction()
        );

        RegisterCommonAction(
            CharacterActionType.Rest,
            new RestAction()
        );

        RegisterCommonAction(
            CharacterActionType.Talk,
            new TalkAction()
        );

        RegisterCommonAction(
            CharacterActionType.Hobby,
            new HobbyAction()
        );
    }


    /// <summary>
    /// 공용 행동 등록
    /// </summary>
    private void RegisterCommonAction(
        CharacterActionType type,
        ICharacterAction action)
    {
        commonActions[type] = action;
    }


    /// <summary>
    /// Factory가 사용할 기본 행동들을 반환
    /// </summary>
    public Dictionary<CharacterActionType, ICharacterAction>
        GetDefaultActions()
    {
        return commonActions;
    }
}