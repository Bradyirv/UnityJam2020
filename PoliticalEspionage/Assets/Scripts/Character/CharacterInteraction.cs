using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class CharacterInteraction : MonoBehaviour
{
    IInteractable interactionTarget;
    PlayerInput playerInput;
    private void OnEnable()
    {
        if (playerInput == null) playerInput = GetComponent<PlayerInput>();
        playerInput.actions.FindAction("Interact").started += HandleAction;
        //playerInput.onActionTriggered += HandleAction;
    }

    private void OnDisable()
    {
        //playerInput.onActionTriggered -= HandleAction;
        playerInput.actions.FindAction("Interact").started -= HandleAction;
    }

    void HandleAction(InputAction.CallbackContext context)
    {
        if (context.action.phase == InputActionPhase.Started && interactionTarget != null) interactionTarget.Interact();
    }

    private void OnTriggerEnter(Collider other)
    {
        IInteractable interactable = other.GetComponent<IInteractable>();

        if (interactable != null) interactionTarget = interactable;
    }

    private void OnTriggerExit(Collider other)
    {
        IInteractable interactable = other.GetComponent<IInteractable>();

        if (interactable != null) interactionTarget = null;
    }
}
