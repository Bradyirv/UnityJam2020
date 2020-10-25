using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

using Daybrayk;
public class CharacterInteraction : MonoBehaviour
{
    [SerializeField]
    GameObject interactVisrep;

    IInteractable interactionTarget;
    PlayerInput playerInput;
    private void OnEnable()
    {
        if (playerInput == null) playerInput = GetComponent<PlayerInput>();
        playerInput.actions.FindAction("Interact").started += HandleAction;
    }

    private void OnDisable()
    {
        playerInput.actions.FindAction("Interact").started -= HandleAction;
    }

    void HandleAction(InputAction.CallbackContext context)
    {
        if (context.action.phase == InputActionPhase.Started && interactionTarget != null)
        {
            interactionTarget.Interact();
            interactVisrep.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        IInteractable interactable = other.GetComponent<IInteractable>();

        if (interactable != null)
        {
            interactionTarget = interactable;
            interactVisrep.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        IInteractable interactable = other.GetComponent<IInteractable>();

        if (interactable != null)
        {
            interactionTarget = null;
            interactVisrep.SetActive(false);
        }
    }
}
