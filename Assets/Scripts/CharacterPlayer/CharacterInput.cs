using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterInput : MonoBehaviour
{
    private Vector3 inputs;
    public Vector3 Inputvector { get { return inputs; } }   //값을 가져와야하는 존재 입력 받으면 애가 결과가 되어야한다

    private KeyCode InputForward = KeyCode.W;
    private KeyCode InputBack = KeyCode.S;
    private KeyCode InputLeft = KeyCode.A;
    private KeyCode InputRight = KeyCode.D;
    private KeyCode InputJump = KeyCode.Space;

    private float horizontal;
    private float vertical;
    private float jump;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Inputs();
    }

    void Inputs()
    {
        horizontal = 0;
        vertical = 0;

        if (Input.GetKey(InputForward)) vertical++;
        if (Input.GetKey(InputBack)) vertical--;
        if (Input.GetKey(InputLeft)) horizontal--;
        if (Input.GetKey(InputRight)) horizontal++;
        if (Input.GetKey(InputJump)) jump = 5f;
            
       inputs = new Vector3(horizontal, jump, vertical);

    }
}
