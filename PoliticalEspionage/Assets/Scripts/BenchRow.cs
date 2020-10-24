using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BenchRow : MonoBehaviour
{
    private int maxSpots = 6;
    public Seat[] Seats;

    public Transform aisleLeft;
    public Transform aisleRight;

    // Might not be necessary
    [System.Serializable]
    public struct Seat
    {
        public bool occupied;
        public Transform TargetA;
        public Transform TargetB;
    }
}
