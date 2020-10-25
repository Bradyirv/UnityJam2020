using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

using Daybrayk;
public class CharacterMovement : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField]
    float speed;
    [SerializeField]
    float angularSpeed;

    Vector3 movementAxis = new Vector3();
    CharacterController controller;
    PlayerInput playerInput;
    Animator anim;

    #region Unity
    private void Start()
    {
        anim = GetComponentInChildren<Animator>();
        controller = GetComponent<CharacterController>();
        movementAxis.y = Physics.gravity.y;
    }
    void Update()
    {
        controller.Move(movementAxis * Time.deltaTime);
        if(movementAxis.WithY(0).sqrMagnitude > 0) transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(movementAxis.WithY(0)), angularSpeed * Time.deltaTime);
    }
    private void OnEnable()
    {
        if (playerInput == null) playerInput = GetComponent<PlayerInput>();
        playerInput.actions.FindAction("Move").performed += HandleAction;
        playerInput.actions.FindAction("Move").canceled += HandleAction;
    }

    private void OnDisable()
    {
        playerInput.actions.FindAction("Move").performed -= HandleAction;
        playerInput.actions.FindAction("Move").canceled -= HandleAction;
    }
    #endregion

    void HandleAction(InputAction.CallbackContext context)
    {
        Vector2 axis = context.action.ReadValue<Vector2>();
        anim.SetFloat("speed", axis.sqrMagnitude);
        movementAxis.x = axis.x * speed;
        movementAxis.z = axis.y * speed;
    }



}
