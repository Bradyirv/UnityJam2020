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

    public void Interact()
    {
        if (AIManager.instance.CalledForNextAI())
        {
            onBellInteract.TryInvoke();
            source.Play();
        }
    }
}
