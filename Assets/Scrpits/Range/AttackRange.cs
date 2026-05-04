using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

[RequireComponent(typeof(SphereCollider))]
public class AttackRange : MonoBehaviour
{
    [SerializeField] private float attackRange;
    [SerializeField] private CharacterFactory characters; // ¿¬°á
    private SphereCollider rangeCollider;

    
    public float AttackRanged => attackRange;

    void Awake()
    {

        rangeCollider = GetComponent<SphereCollider>();
        rangeCollider.isTrigger = true;
    }

    void Start()
    {
        
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
