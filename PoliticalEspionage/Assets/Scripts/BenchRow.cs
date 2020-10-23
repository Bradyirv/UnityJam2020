using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BenchRow : MonoBehaviour
{
    private int maxSpots = 6;
    public List<int> seatsTaken = new List<int>();

    public Transform aisle;

    public Transform[] Seat1;
    public Transform[] Seat2;
    public Transform[] Seat3;
    public Transform[] Seat4;
    public Transform[] Seat5;
    public Transform[] Seat6;
}
