using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterThink : MonoBehaviour
{
    // 현재 생각
    [SerializeField] private ThoughtType currentThought = ThoughtType.None;
    // 외부 읽기 전용
    public ThoughtType CurrentThought => currentThought;
    // 등록된 생각들
    private Dictionary<ThoughtType, ICharacterThought> thoughtDictionary
        = new Dictionary<ThoughtType, ICharacterThought>();

    private ICharacterThought currentThoughtObject;

    // 외부 읽기 전용
    public ICharacterThought CurrentThoughtObject => currentThoughtObject;
    private void Awake()
    {
        RegisterThoughts();
    }

    /// <summary>
    /// 생각 등록
    /// </summary>
    private void RegisterThoughts()
    {
        // 나중에 등록
        // thoughtDictionary.Add(ThoughtType.SatisfyHunger, new HungerThought());
        // thoughtDictionary.Add(ThoughtType.Sleep, new SleepThought());
        // thoughtDictionary.Add(ThoughtType.Fight, new FightThought());
        // thoughtDictionary.Add(ThoughtType.Escape, new EscapeThought());
    }

    public void ChangeThought(ThoughtType newThought)
    {
        if (currentThought == newThought)
            return;

        currentThoughtObject?.Exit();

        currentThought = newThought;

        if (thoughtDictionary.TryGetValue(newThought, out currentThoughtObject))
        {
            currentThoughtObject.Enter();
        }
    }
}