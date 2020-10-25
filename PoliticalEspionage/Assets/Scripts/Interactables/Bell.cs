using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bell : MonoBehaviour, IInteractable
{
    public AudioClip sound;
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
            source.PlayOneShot(sound);
            trigger.enabled = false;
        }
    }

    public void ActivateTrigger()
    {
        trigger.enabled = true;
    }
}
