using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIBehaviour : MonoBehaviour
{
    //public enum RoyaltyStatus
    //{
    //    Peasant,
    //    Squire,
    //    Knight,
    //    Lord,
    //    King
    //}

    //public enum State
    //{
    //    LookForSeat = 0,
    //    GoingToSeat,
    //    Wait,
    //    GoToConfess,
    //    Confess,
    //    Leave
    //}
    //public State myState = State.LookForSeat;

    // Components
    private Animator anim;
    private AudioSource audioSource;
    public NavMeshAgent agent;

    // Target Locations
    public BenchRow myBench = null;
    public bool calledForPrayer = false;
    public bool madePrayer = false;
    public bool left = false;
    public int mySeat = -1;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        audioSource = GetComponent<AudioSource>();
    }

    public void Init()
    {
        // Determine what royalty level can be spawned based on Friar rating
        // Set up how much influence my secret has
        // Assign my secret from a SecretManager (Dialogue for prayer booth)
    }

    public void CallForConfession()
    {
        calledForPrayer = true;
        anim.SetTrigger("NextState");
    }

    public void PlayAudio()
    {

    }
}
