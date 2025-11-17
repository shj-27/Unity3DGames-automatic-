using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    [Header("이동 설정")]
    [SerializeField] private float moveSpeed = 1f;
    [SerializeField] private float jumpPawer = 8f;


    private CharacterController controller;
    private Animator animator;
    private Vector3 velocity;
    private CharacterController characterController { get { return controller; } }
    private float MoveSpeed{get{ return moveSpeed; } set { moveSpeed = value; } }
    private void Awake()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }

    public void Moving(Vector3 inputs)
    {
        if (controller == null) return;


        
        Vector3 inputDir = new Vector3(inputs.x, 0, inputs.z);
        if (inputDir.magnitude>0.1f)
        {
            animator.SetBool("Move", true);
        }
        else
        {
            animator.SetBool("Move", false);
        }
        velocity = transform.right * inputDir.x+transform.forward * inputDir.z;

        velocity = velocity.normalized * moveSpeed * Time.deltaTime;

        characterController.Move(velocity);
    }
}
