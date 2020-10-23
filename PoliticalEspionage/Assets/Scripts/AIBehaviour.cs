using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    public enum State
    {
        ValidateSeat = 0,
        GoingToSeat,
        Wait,
        GoToConfess,
        Confess,
        Leave
    }
    public State myState = State.ValidateSeat;
    public BenchRow myBench;

    public void Init()
    {
        // Determine what royalty level can be spawned based on Friar rating
    }
}
