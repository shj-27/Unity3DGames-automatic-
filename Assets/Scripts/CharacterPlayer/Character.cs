using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{

    

    private CharacterMovement characterMovement;
    private CharacterInput characterInput;

    private void Awake()
    {
        characterMovement = GetComponent<CharacterMovement>();
        characterInput = GetComponent<CharacterInput>();
    }

    private void Update()
    {
        Vector3 a = characterInput.Inputvector;
        characterMovement.Moving(a);
    }

}
