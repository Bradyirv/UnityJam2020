using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bell : MonoBehaviour, IInteractable
{
    public AudioClip sound;
    public AudioSource source;

    public void Interact()
    {
        Debug.Log("Bell");
        source.PlayOneShot(sound);
        AIManager.instance.CalledForNextAI();
    }
}
