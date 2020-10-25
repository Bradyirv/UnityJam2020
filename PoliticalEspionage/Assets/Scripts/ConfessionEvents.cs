using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

using Daybrayk;
public class ConfessionEvents : MonoBehaviour
{
    public UnityEvent onConfessionStart;
    public UnityEvent onConfessionEnd;
    private void OnEnable()
    {
        ConfessionManager.onConfessionStart += ConfessionStartHandler;
        ConfessionManager.onConfessionFinish += ConfessionFinishHandler;
    }

    private void OnDisable()
    {
        ConfessionManager.onConfessionStart -= ConfessionStartHandler;
        ConfessionManager.onConfessionFinish -= ConfessionFinishHandler;
        
    }

    void ConfessionStartHandler()
    {
        onConfessionStart.TryInvoke();
    }

    void ConfessionFinishHandler()
    {
        onConfessionEnd.TryInvoke();
    }
}
