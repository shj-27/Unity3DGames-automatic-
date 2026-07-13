using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 캐릭터 상태 등록
/// </summary>
public static class CharacterStateRegisters
{
    /// <summary>
    /// 공용 생각 등록
    /// </summary>
    public class CharacterThoughtRegister
    {
        public Dictionary<ThoughtType, ICharacterThought> Register(Character owner)
        {
            Dictionary<ThoughtType, ICharacterThought> thoughts = new();

            //thoughts.Add(ThoughtType.SatisfyHunger, new HungerThought(owner));
            //thoughts.Add(ThoughtType.Sleep, new SleepThought(owner));
            //thoughts.Add(ThoughtType.Rest, new RestThought(owner));

            //thoughts.Add(ThoughtType.Socialize, new SocializeThought(owner));
            //thoughts.Add(ThoughtType.Work, new WorkThought(owner));
            //thoughts.Add(ThoughtType.Train, new TrainThought(owner));

            //thoughts.Add(ThoughtType.Heal, new HealThought(owner));
            //thoughts.Add(ThoughtType.SeekSafety, new SeekSafetyThought(owner));

            //thoughts.Add(ThoughtType.Fight, new FightThought(owner));
            //thoughts.Add(ThoughtType.Escape, new EscapeThought(owner));

            return thoughts;
        }
    }
    //    /// <summary>
    //    /// 플레이어 상태 등록
    //    /// </summary>
    //    public class PlayerStateRegister
    //    {
    //        public Dictionary<CharacterStateType, ICharacterState> Register(Character owner)
    //        {
    //            Dictionary<CharacterStateType, ICharacterState> states = new();

    //            states.Add(CharacterStateType.Idle, new CharacterIdleState(owner));
    //            states.Add(CharacterStateType.Move, new CharacterMoveState(owner));
    //            states.Add(CharacterStateType.Death, new CharacterDeathState(owner));

    //            return states;
    //        }
    //    }

    //    /// <summary>
    //    /// 몬스터 상태 등록
    //    /// </summary>
    //    public class MonsterStateRegister
    //    {
    //        public Dictionary<CharacterStateType, ICharacterState> Register(Character owner)
    //        {
    //            Dictionary<CharacterStateType, ICharacterState> states = new();

    //            states.Add(CharacterStateType.Idle, new MonsterIdleState(owner));
    //            states.Add(CharacterStateType.Move, new MonsterMoveState(owner));
    //            states.Add(CharacterStateType.Death, new MonsterDeathState(owner));

    //            return states;
    //        }
    //    }

    //    /// <summary>
    //    /// NPC 상태 등록
    //    /// </summary>
    //    public class NPCStateRegister
    //    {
    //        public Dictionary<CharacterStateType, ICharacterState> Register(Character owner)
    //        {
    //            Dictionary<CharacterStateType, ICharacterState> states = new();

    //            states.Add(CharacterStateType.Idle, new NPCIdleState(owner));
    //            states.Add(CharacterStateType.Move, new NPCMoveState(owner));
    //            states.Add(CharacterStateType.Death, new NPCDeathState(owner));

    //            return states;
    //        }
    //    }

    //    /// <summary>
    //    /// 펫 상태 등록
    //    /// </summary>
    //    public class PetStateRegister
    //    {
    //        public Dictionary<CharacterStateType, ICharacterState> Register(Character owner)
    //        {
    //            Dictionary<CharacterStateType, ICharacterState> states = new();

    //            states.Add(CharacterStateType.Idle, new PetIdleState(owner));
    //            states.Add(CharacterStateType.Move, new PetMoveState(owner));
    //            states.Add(CharacterStateType.Death, new PetDeathState(owner));

    //            return states;
    //        }
    //    }
}