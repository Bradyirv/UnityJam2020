using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

using Daybrayk;
public class Bell : MonoBehaviour, IInteractable
{
    public UnityEvent onBellInteract;
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
            trigger.gameObject.SetActive(false);
            onBellInteract.TryInvoke();
            source.Play();
            trigger.enabled = false;
        }
    }

    public void ActivateTrigger()
    {
        trigger.enabled = true;
    }
}
