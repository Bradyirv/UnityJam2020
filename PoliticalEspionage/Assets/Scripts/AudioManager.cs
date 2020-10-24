using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    public enum OneShotSound
    {
        FootStep
    }

    public AudioClip footstep;

    private void Awake()
    {
        if (instance) Destroy(this);
        else instance = this;
    }

    public void PlayOneShot(OneShotSound clip, AudioSource source)
    {
        source.clip = null;
        switch (clip)
        {
            case OneShotSound.FootStep:
                source.clip = footstep;
                break;
            default:
                break;
        }

        if(source.clip != null)
        source.PlayOneShot(footstep);
    }
}
