using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

[RequireComponent(typeof(SphereCollider))]
public class AttackRange : MonoBehaviour
{
    [SerializeField] private float attackRange;
    [SerializeField] private Characters characters; // 연결
    private SphereCollider rangeCollider;

    
    public float AttackRanged => attackRange;

    void Awake()
    {

        rangeCollider = GetComponent<SphereCollider>();
        rangeCollider.isTrigger = true;
    }

    void Start()
    {
        // Characters에서 값 받아오기
        attackRange = characters.GetRandomRange();
    }

    public void SetRange(float value)
    {
        attackRange = value;
        rangeCollider.radius = attackRange;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}
