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

    IEnumerator ValidateSeat()
    {
        BenchRow bench = null;

        // Get a bench with seats
        bool validateBench = true;
        while (validateBench)
        {
            int r = Random.Range(0, benches.Count);
            if (SeatsAreAvailable(benches[r]))
            {
                bench = benches[r];
                validateBench = false;
            }
        }

        bool validateSeat = true;
        while (validateSeat)
        {
            int r = Random.Range(0, 6);
            if (SeatNotTaken(r, bench))
            {

            }
        }

        yield return null;
    }

    private bool SeatsAreAvailable(BenchRow bench)
    {
        if (bench.seatsTaken.Count == 6) return false;
        else return true;
    }

    private bool SeatNotTaken(int seat, BenchRow bench)
    {
        if (bench.seatsTaken.Contains(seat) == false) return true;
        else return false;
    }
}
