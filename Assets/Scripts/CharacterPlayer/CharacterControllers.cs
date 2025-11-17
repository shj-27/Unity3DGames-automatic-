using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControllers : MonoBehaviour
{


    [SerializeField] private float speed; // 이동 속도
    [SerializeField] private float rotateSpeed; // 회전 속도
    [SerializeField] private float jumpPower;   // 점프 세기

    [SerializeField] private float gravity; // 중력 수치

    [SerializeField] private Transform ground;
    [SerializeField] private float groundCheckDistance = 0.4f;  // 이 거리 안에 땅 있으면 착지
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private bool isGrounded => Physics.Raycast(transform.position + Vector3.up * 0.1f, Vector3.down, groundCheckDistance, groundLayer);

    
    private float ySpeed = 0f; // 수직 하강 속도
    private CharacterController cc;

    private Animator ani;

    private Vector3 moveDirection = Vector3.zero;   // 최종 이동 벡터 (x, y, z 다 포함)
    // Start is called before the first frame update
    private void Awake()
    {
        cc = GetComponent<CharacterController>();
        ani = GetComponent<Animator>();
    }

    void Start()
    {

    }

    // Update is called once per frame
    private void Update()
    {
        Move();         // 수평 이동
        Jump();         // 점프 입력
        GravityDown();  // 중력만 담당
        ApplyMove();    // 이동확인
    }

   
    private void Move()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        Vector3 horizontal = new Vector3(h, 0, v).normalized;

        // 회전
        if (horizontal.magnitude > 0.1f)
        {
            Quaternion targetRot = Quaternion.LookRotation(horizontal);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRot, rotateSpeed * Time.deltaTime);
        }

        // 수평 이동
        moveDirection.x = horizontal.x * speed;
        moveDirection.z = horizontal.z * speed;
    }

    // 점프만 담당 (착지했을 때만 힘 줌)
    private void Jump()
    {
        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            moveDirection.y = jumpPower;//점프
           
        }
    }

    // 중력만 담당
    private void GravityDown()
    {
        if (!isGrounded)
        {
            moveDirection.y -= gravity * Time.deltaTime;
        }
        else if (moveDirection.y < 0)
        {
            moveDirection.y = -1f;  // 땅에 붙어 있게 살짝 내림
        }
    }

    // 최종 이동
    private void ApplyMove()
    {
        cc.Move(moveDirection * Time.deltaTime);

        float horizontalSpeed = new Vector3(moveDirection.x, 0, moveDirection.z).sqrMagnitude;
        ani.SetBool("isMoving", horizontalSpeed > 0.01f);
        ani.SetBool("isJumping", !isGrounded && moveDirection.y > 0.1f);
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = isGrounded ? Color.green : Color.red;
        Gizmos.DrawRay(transform.position + Vector3.up * 0.1f, Vector3.down * groundCheckDistance);
    }
}

