using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Daybrayk;

[RequireComponent(typeof(Collider))]
public class DialogueTrigger : MonoBehaviour, IInteractable
{
    public Dialogue dialogue;
    DialogueManager dialogueManager;

    private void Start()
    {
        dialogueManager = FindObjectOfType<DialogueManager>();
    }

    public void Interact()
    {
        dialogueManager.StartDialogue(dialogue);
    }
}
