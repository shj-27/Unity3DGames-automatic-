using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] private string id;
    [SerializeField] private EntityType entityType;

    [SerializeField] private ThoughtType currentThought = ThoughtType.None;
    [SerializeField] private float eyesValue;

    private CharacterData characterData;
    private ICharacterThought currentThoughtInstance;
    public string ID => id;
    public EntityType EntityType => entityType;
    public ThoughtType CurrentThought => currentThought;
    public float EyesValue => eyesValue;
    public CharacterData CharacterData => characterData;

    [SerializeField] private Transform headSocket;
    [SerializeField] private Transform bodySocket;
    [SerializeField] private Transform legSocket;

    private CharacterPart headPart;
    private CharacterPart bodyPart;
    private CharacterPart legPart;

    [SerializeField] private CharacterEyes eyes;
    public CharacterEyes Eyes => eyes;

    private CharacterStateRegisters.CharacterThoughtRegister thoughtRegister;
    public CharacterStateRegisters.CharacterThoughtRegister ThoughtRegister => thoughtRegister;

    public void SetID(string newId, EntityType newEntityType)
    {
        if (!string.IsNullOrEmpty(id))
            return;

        id = newId;
        entityType = newEntityType;
    }

    private void RefreshAppearance()
    {
        GameObject headObject = Instantiate(characterData.head, headSocket);
        headPart = headObject.GetComponent<CharacterPart>();
        if (headPart != null) headPart.Initialize(this);

        GameObject bodyObject = Instantiate(characterData.top, bodySocket);
        bodyPart = bodyObject.GetComponent<CharacterPart>();
        if (bodyPart != null) bodyPart.Initialize(this);

        GameObject legObject = Instantiate(characterData.bottom, legSocket);
        legPart = legObject.GetComponent<CharacterPart>();
        if (legPart != null) legPart.Initialize(this);
    }

    private void Start()
    {
        CharacterInventory inventory = CharacterManager.Instance.Inventory;

        characterData = inventory.GetCharacterByID(id);
        if (characterData == null)
            return;

        eyesValue = characterData.eyes;

        eyes.Initialize(this);
        RefreshAppearance();
        UpdateThought();
    }

    private void UpdateThought()
    {
        if (!CharacterManager.Instance.TryGetCharacterCondition(
        id,
        out float hunger,
        out float fatigue))
            return;

        if (currentThought == ThoughtType.None)
        {
            // 1. 확률 계산으로 enum 결정
            currentThought = RollThoughtProbability(hunger, fatigue);

            // 2. 생각 등록소 준비
            thoughtRegister ??= new CharacterStateRegisters.CharacterThoughtRegister();

            // 3. 등록된 생각 목록 가져오기
            Dictionary<ThoughtType, ICharacterThought> thoughts = thoughtRegister.Register(this);

            // 4. currentThought에 해당하는 등록 객체 사용
            ICharacterThought thought = thoughts[currentThought];
        }
    }

    private ThoughtType RollThoughtProbability(float currentHunger, float currentFatigue)
    {
        float[] thoughtScores = new float[System.Enum.GetValues(typeof(ThoughtType)).Length];

        thoughtScores[(int)ThoughtType.SatisfyHunger] = CheckHungerThought(currentHunger);
        thoughtScores[(int)ThoughtType.Sleep] = CheckSleepThought(currentFatigue);
        thoughtScores[(int)ThoughtType.Rest] = CheckRestThought();
        thoughtScores[(int)ThoughtType.Socialize] = CheckSocializeThought();
        thoughtScores[(int)ThoughtType.Work] = CheckWorkThought();
        thoughtScores[(int)ThoughtType.Train] = CheckTrainThought();
        thoughtScores[(int)ThoughtType.Heal] = CheckHealThought();
        thoughtScores[(int)ThoughtType.SeekSafety] = CheckSeekSafetyThought();
        thoughtScores[(int)ThoughtType.Fight] = CheckFightThought();
        thoughtScores[(int)ThoughtType.Escape] = CheckEscapeThought();

        float total = 0f;

        for (int i = 1; i < thoughtScores.Length; i++)
            total += thoughtScores[i];

        if (total <= 0f)
            return ThoughtType.None;

        float[] percent = new float[thoughtScores.Length];

        for (int i = 1; i < thoughtScores.Length; i++)
            percent[i] = (thoughtScores[i] / total) * 100f;

        float roll = Random.Range(0f, 100f);

        float current = 0f;

        for (int i = 1; i < percent.Length; i++)
        {
            current += percent[i];

            if (roll <= current)
                return (ThoughtType)i;
        }

        return ThoughtType.None;
    }

    private float CheckHungerThought(float currentHunger)
    {
        int hunger = Mathf.FloorToInt(currentHunger);

        if (hunger <= 0)
            return 0f;

        float minScore = hunger * 2f - 1f;
        float maxScore = hunger * 2f;

        return Random.Range(minScore, maxScore);
    }

    private float CheckSleepThought(float currentFatigue)
    {
        int fatigue = Mathf.FloorToInt(currentFatigue);
        int tired = 100 - fatigue;

        if (tired <= 0)
            return 0f;

        float minScore = tired * 2f - 1f;
        float maxScore = tired * 2f;

        return Random.Range(minScore, maxScore);
    }

    private float CheckRestThought() => 0f;
    private float CheckSocializeThought() => 0f;
    private float CheckWorkThought() => 0f;
    private float CheckTrainThought() => 0f;
    private float CheckHealThought() => 0f;
    private float CheckSeekSafetyThought() => 0f;
    private float CheckFightThought() => 0f;
    private float CheckEscapeThought() => 0f;
}