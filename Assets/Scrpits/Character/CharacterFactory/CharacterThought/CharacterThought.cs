using UnityEngine;

/// <summary>
/// 캐릭터의 생각을 담당하는 뇌
///
/// 역할:
/// - 외부 정보 수용 및 해석
/// - 목표별 기초 확률 설정
/// - 재고민 여부 판단
/// - 성격과 상황에 따른 확률 조정
/// - 최종 목표 결정
///
/// 실제 행동의 실행은 담당하지 않음
/// </summary>
public class CharacterThought : MonoBehaviour
{
    // 자신과 연결된 캐릭터
    private Character character;

    // 자신의 캐릭터 ID
    private string characterId;

    // 현재 새로운 생각을 하고 있는지
    private bool isThinking = false;

    // 외부에서 전달받은 조언 목표
    private CharacterThoughtGoal adviceGoal;

    // 범용 코루틴
    private Autos autos;

    // 재고민 판단의 기준 결정 포인트
    private const float decisionPointThreshold = 50f;

    /// <summary>
    /// 자신이 어떤 캐릭터의 Thought인지 확인
    /// </summary>
    public void Identify()
    {
        character = GetComponent<Character>();

        if (character == null)
            return;

        characterId = character.ID;
        autos = FindFirstObjectByType<Autos>();
    }

    /// <summary>
    /// 생각의 시작
    /// </summary>
    public void FormulateGoals(CharacterThoughtGoal[] goals)
    {
        if (isThinking)
            return;

        if (goals == null || goals.Length == 0)
            return;

        if (character == null || autos == null)
            return;

        isThinking = true;

        // 결정 포인트
        float decisionPoint =
            character.Data.characterData.personalityData.decisionPoint;

        // 목표별 기초 확률 설정
        float[] probabilities = SetInitialProbabilities(goals.Length);

        // 결정 포인트가 기준보다 낮으면 대기 코루틴 실행
        if (decisionPoint < decisionPointThreshold)
        {
            StartCoroutine(
                autos.WaitCoroutine(
                    decisionPointThreshold - decisionPoint,
                    GetRethinkProbability(decisionPoint),
                    () => RethinkGoals(goals),
                    () => AdjustAndDecideGoal(goals, probabilities)
                )
            );

            return;
        }

        // 기준 이상이면 확률 조정 단계로 진행
        AdjustAndDecideGoal(goals, probabilities);
    }

    /// <summary>
    /// 목표별 기초 확률 설정
    /// </summary>
    private float[] SetInitialProbabilities(int goalCount)
    {
        float[] probabilities = new float[goalCount];

        if (goalCount <= 0)
            return probabilities;

        // 모든 목표에 균등한 확률 부여
        float probability = 1f / goalCount;

        for (int i = 0; i < goalCount; i++)
        {
            probabilities[i] = probability;
        }

        return probabilities;
    }

    /// <summary>
    /// 메서드 1: 재고민 확률 반환
    /// </summary>
    private float GetRethinkProbability(float decisionPoint)
    {
        int decisionRange = (int)decisionPoint / 10;

        return decisionRange switch
        {
            4 => 0.5f, // 40~49: 50%
            3 => 0.6f, // 30~39: 60%
            2 => 0.7f, // 20~29: 70%
            _ => 0f
        };
    }

    /// <summary>
    /// 재고민을 선택하면 생각의 시작으로 돌아감
    /// </summary>
    private void RethinkGoals(CharacterThoughtGoal[] goals)
    {
        isThinking = false;
        FormulateGoals(goals);
    }

    /// <summary>
    /// 메서드 2: 목표별 확률 조정 후 최종 결정으로 전달
    /// </summary>
    private void AdjustAndDecideGoal(
        CharacterThoughtGoal[] goals,
        float[] probabilities)
    {
        probabilities = AdjustGoalProbabilities(probabilities);

        DecideFinalGoal(goals, probabilities);
    }

    /// <summary>
    /// 성격과 상황에 따라 목표별 확률 조정
    /// </summary>
    private float[] AdjustGoalProbabilities(float[] probabilities)
    {
        // 추후 성격과 상황에 따라 목표별 확률 조정

        return probabilities;
    }

    /// <summary>
    /// 메서드 3: 최종 목표 결정
    /// </summary>
    private void DecideFinalGoal(
        CharacterThoughtGoal[] goals,
        float[] probabilities)
    {
        int selectedIndex = Randoms.RandomFloat(probabilities);

        if (selectedIndex < 0 || selectedIndex >= goals.Length)
        {
            isThinking = false;
            return;
        }

        adviceGoal = goals[selectedIndex];
        isThinking = false;
    }
}

