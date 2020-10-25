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
    public Animator anim { get; private set; }

    #region Unity
    private void Start()
    {
        anim = GetComponentInChildren<Animator>();
        controller = GetComponent<CharacterController>();
        movementAxis.y = Physics.gravity.y;
    }
    void Update()
    {
        controller.Move(transform.forward * movementAxis.z * Time.deltaTime);
        transform.Rotate(Vector3.up * movementAxis.x * Time.deltaTime);
        //if(movementAxis.WithY(0).sqrMagnitude > 0) transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(movementAxis.WithY(0)), angularSpeed * Time.deltaTime);
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
        anim.SetFloat("speed", axis.y);
        movementAxis.x = axis.x * angularSpeed;
        movementAxis.z = axis.y * speed;
    }

    public void CinematicMove(Transform pos)
    {
        anim.SetFloat("speed", speed);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(pos.position.WithY(0) - transform.position.WithY(0)), angularSpeed * Time.deltaTime);
        controller.Move((pos.position - transform.position).normalized * Time.deltaTime * speed);
    }

}
