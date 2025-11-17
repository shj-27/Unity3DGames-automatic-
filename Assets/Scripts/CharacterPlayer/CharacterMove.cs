using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMove : MonoBehaviour
{

    [SerializeField] private float moveSpeed;
    private float horizontal;
    private float vertical;
    private CharacterController controller;

    private void Awake()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
        controller = GetComponent<CharacterController>();
    }



    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Moving();
    }


    private void FixedUpdate()
    {

    }

    private void Moving()
    {
        Vector3 dir = new Vector3(horizontal, 0, vertical) * moveSpeed;
        controller.Move(dir);
    }
}
