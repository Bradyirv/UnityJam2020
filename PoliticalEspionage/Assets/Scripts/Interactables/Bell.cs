using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bell : MonoBehaviour, IInteractable
{
    public AudioSource source;
    public BoxCollider trigger;

    private void Start()
    {
        ConfessionManager.onConfessionFinish += ActivateTrigger;
    }

    public void Interact()
    {
        if (AIManager.instance.CalledForNextAI())
        {
            source.Play();
            trigger.enabled = false;
        }
    }

    public void ActivateTrigger()
    {
        trigger.enabled = true;
    }
}
