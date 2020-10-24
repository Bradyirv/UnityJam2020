using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SMB_LookForSeat : StateMachineBehaviour
{
    private AIBehaviour me;
    private Coroutine lookForSeat;
    bool foundBenchWithSeat = false;
    bool foundOpenSeat = false;
    bool complete = false;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        me = animator.GetComponent<AIBehaviour>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // Find bench
        if (me.myBench == null)
        {
            int r = Random.Range(0, BenchRowManager.instance.benches.Count);
            Debug.Log(r);
            if (BenchRowManager.instance.SeatsAreAvailable(BenchRowManager.instance.benches[r]))
            {
                me.myBench = BenchRowManager.instance.benches[r];
            }
        }
        // Find Seat
        else if(me.mySeat == -1)
        {
            if(foundOpenSeat == false)
            {
                int r = Random.Range(0, 6);
                Debug.Log(r);
                if (BenchRowManager.instance.SeatTaken(r, me.myBench) == false)
                {
                    me.mySeat = r;
                }
            }
        }
        // We have a bench and seat, left's randomly choose left or right aisle
        else if(complete == false)
        {
            int r = Random.Range(0,2);
            if (r == 0) me.left = true;
            else me.left = false;

            animator.SetBool("LeftAisle", me.left);
            animator.SetTrigger("NextState");
            complete = true;
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{

    //}

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
