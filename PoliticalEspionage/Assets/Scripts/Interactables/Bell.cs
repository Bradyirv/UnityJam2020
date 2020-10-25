using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bell : MonoBehaviour, IInteractable
{
    public AudioClip sound;
    public AudioSource source;

    public void Interact()
    {
        source.PlayOneShot(sound);
        AIManager.instance.CalledForNextAI();
    }
}
