using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.AI;
using TMPro;

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
    [HideInInspector] public NavMeshAgent agent;
    public AIManager.AI myInformation;
    public TextMeshProUGUI NameGUI;

    public Material[] materials;
    public GameObject[] models;

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
        // Set Namebar
        NameGUI.text = myInformation.first + " " + myInformation.last + "\nof Clan " + myInformation.clan;
        // Set Character model and material
        int r = Random.Range(0, 5);
        models[r].SetActive(true);
        int r2 = Random.Range(0, materials.Length);
        models[r].GetComponent<SkinnedMeshRenderer>().sharedMaterial = materials[r2];

        // Determine what royalty level can be spawned based on Friar rating
        // Set up how much influence my secret has
        // Assign my secret from a SecretManager (Dialogue for prayer booth)
    }

    public void callForPrayer()
    {
        calledForPrayer = true;
        anim.ResetTrigger("NextState");
        if (!anim.GetCurrentAnimatorStateInfo(0).IsName("GoToSeat")) anim.SetTrigger("NextState");
    }

    public void CompletedPrayer()
    {
        madePrayer = true;
        anim.SetTrigger("NextState");
    }
}
