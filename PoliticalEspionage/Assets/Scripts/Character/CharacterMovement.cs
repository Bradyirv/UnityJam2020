using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CharacterMovement : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField]
    float speed;

    Vector3 movementAxis = new Vector3();

    CharacterController controller;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        movementAxis.x = Input.GetAxis("Horizontal");
        movementAxis.y = Physics.gravity.y;
        movementAxis.z = Input.GetAxis("Vertical");

        controller.Move(movementAxis * Time.deltaTime * speed);
    }
}
