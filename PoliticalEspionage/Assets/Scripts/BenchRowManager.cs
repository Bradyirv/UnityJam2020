using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BenchRowManager : MonoBehaviour
{
    public static BenchRowManager instance;
    public List<BenchRow> benches;

    private void Awake()
    {
        if (instance) Destroy(this);
        else instance = this;
    }

    public bool SeatsAreAvailable(BenchRow bench)
    {
        for(int i=0; i<bench.Seats.Length; i++)
        {
            if (bench.Seats[i].occupied) continue;
            else return true;
        }
        return false;
    }

    public bool SeatTaken(int seat, BenchRow bench)
    {
        if (bench.Seats[seat].occupied == false)
        {
            bench.Seats[seat].occupied = true;
            return false;
        }
        else return true;
    }
}