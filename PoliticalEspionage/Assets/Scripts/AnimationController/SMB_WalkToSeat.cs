using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SMB_WalkToSeat : StateMachineBehaviour
{
    AIBehaviour me;
    private Transform targetA;
    private Transform targetB;
    private Transform targetC;
    private bool AComplete = false;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        me = animator.GetComponent<AIBehaviour>();

        // Bench Aisle Node
        if(me.left) targetA = me.myBench.aisleLeft;
        else targetA = me.myBench.aisleRight;

        // Bench Seat Node
        targetB = me.myBench.Seats[me.mySeat].TargetB;

        // Confession Node
        targetC = AIManager.instance.confessionSeatLocation;
        me.agent.destination = targetA.position;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if(me.madePrayer == false)
        {
            if(me.calledForPrayer == false)
            {
                if(AComplete == false)
                {
                    if (Vector3.Distance(me.transform.position, me.agent.pathEndPosition) < 0.2f)
                    {
                        me.agent.destination = targetB.position;
                        AComplete = true;
                    }
                }
                else
                {
                    if (Vector3.Distance(me.transform.position, me.agent.pathEndPosition) < 0.2f)
                    {
                        me.transform.forward = targetB.forward;
                        animator.SetTrigger("NextState");
                    }
                }
            }
            else
            {
                me.agent.destination = targetC.position;
                if (Vector3.Distance(me.transform.position, me.agent.pathEndPosition) < 0.2f)
                {
                    animator.SetTrigger("NextState");
                }
            }
        }
        else
        {
            me.agent.destination = AIManager.instance.AISpawnLocation.position;
            if (Vector3.Distance(me.transform.position, me.agent.pathEndPosition) < 0.2f)
            {
                AIManager.instance.Dispose(me);
            }
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
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
