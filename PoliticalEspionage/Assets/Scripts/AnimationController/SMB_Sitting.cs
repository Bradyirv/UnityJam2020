using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SMB_Sitting : StateMachineBehaviour
{
    AIBehaviour me;
    float timeWaiting = 0;
    float timeToWait = 0;
    bool triggeredAndRageQuitting;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        me = animator.GetComponent<AIBehaviour>();
        timeToWait = Random.Range(30,90);
        timeWaiting = 0;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if(!triggeredAndRageQuitting)
        {
            if(me.calledForPrayer == false)
            {
                if(timeWaiting > timeToWait)
                {
                    Debug.Log("Leave Church: " + me.myInformation.first + " " + me.myInformation.last);

                    me.madePrayer = true;
                    AIManager.instance.waitingAI.Remove(me);

                    triggeredAndRageQuitting = true;
                    animator.SetTrigger("NextState");
                }
                else
                {
                    timeWaiting += Time.deltaTime;
                }
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
