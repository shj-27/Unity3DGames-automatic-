using System.Collections;
using UnityEngine;
using System.Collections.Generic;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class CharacterEyes : MonoBehaviour
{
    private Character owner;
    public Character Owner => owner;

    public float EyesValue => owner.EyesValue;

    [SerializeField]
    [Range(0f, 360f)]
    private float eyesAngle = 120f;

    public float EyesAngle => eyesAngle;

    private Dictionary<EntityType, int> visibleCounts = new();
    public Dictionary<EntityType, int> VisibleCounts => visibleCounts;

    private HashSet<Character> visibleCharacters = new();
    public HashSet<Character> VisibleCharacters => visibleCharacters;

    [SerializeField] private int CharacterCount;
    [SerializeField] private int friendlyCount;
    [SerializeField] private int neutralCount;
    [SerializeField] private int enemyCount;
    [SerializeField] private int itemCount;

    public void Initialize(Character character)
    {
        owner = character;

        visibleCounts = new Dictionary<EntityType, int>()
        {
            { EntityType.Character, 0 },
            { EntityType.Friendly, 0 },
            { EntityType.Neutral, 0 },
            { EntityType.Enemy, 0 },
            { EntityType.Item, 0 }
        };
        Debug.Log("코루틴 시작");
        StartCoroutine(EyeRoutine());
    }

    private IEnumerator EyeRoutine()
    {
        while (true)
        {
            Debug.Log("눈 탐지 시작");
            Scan();
            Detect();
            yield return new WaitForSeconds(0.2f);
        }
    }

    private void Scan()
    {
        // 필요 시 확장용
    }

    private void Detect()
    {
        
        visibleCounts[EntityType.Character] = 0;
        visibleCounts[EntityType.Friendly] = 0;
        visibleCounts[EntityType.Neutral] = 0;
        visibleCounts[EntityType.Enemy] = 0;
        visibleCounts[EntityType.Item] = 0;

        Collider[] hits = Physics.OverlapSphere(transform.position, EyesValue);

        float halfAngle = EyesAngle * 0.5f;

        //forward 기준으로 통일
        Vector3 forward = owner.transform.forward;

        foreach (Collider hit in hits)
        {
            if (hit.transform == transform)
                continue;

            Character target = hit.GetComponent<Character>();
            if (target == null)
                continue;

            Vector3 dir = (hit.transform.position - transform.position).normalized;

            //Y축 기준 평면 시야 유지 (수평 시야)
            Vector3 flatForward = Vector3.ProjectOnPlane(forward, Vector3.up).normalized;
            Vector3 flatDir = Vector3.ProjectOnPlane(dir, Vector3.up).normalized;

            if (Vector3.Angle(flatForward, flatDir) <= halfAngle)
            {
                EntityType type = target.EntityType;
                visibleCounts[type]++;
            }
            
        }
        CharacterCount = visibleCounts[EntityType.Character];
        friendlyCount = visibleCounts[EntityType.Friendly];
        neutralCount = visibleCounts[EntityType.Neutral];
        enemyCount = visibleCounts[EntityType.Enemy];
        itemCount = visibleCounts[EntityType.Item];
    
    }

#if UNITY_EDITOR
    private void OnDrawGizmosSelected()
    {
        if (owner == null)
            return;

        Vector3 forward = owner.transform.forward;
        Vector3 flatForward = Vector3.ProjectOnPlane(forward, Vector3.up).normalized;

        float halfAngle = EyesAngle * 0.5f;

        Gizmos.color = Color.green;

        // 중심선
        Gizmos.DrawLine(
            transform.position,
            transform.position + flatForward * EyesValue
        );

        Handles.color = new Color(0f, 1f, 0f, 0.2f);

        Handles.DrawSolidArc(
            transform.position,
            Vector3.up,
            Quaternion.Euler(0f, -halfAngle, 0f) * flatForward,
            EyesAngle,
            EyesValue
        );

        Handles.color = Color.green;

        Handles.DrawWireArc(
            transform.position,
            Vector3.up,
            Quaternion.Euler(0f, -halfAngle, 0f) * flatForward,
            EyesAngle,
            EyesValue
        );
    }
#endif
}