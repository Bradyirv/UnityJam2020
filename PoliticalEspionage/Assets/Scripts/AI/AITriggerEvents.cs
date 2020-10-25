using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

using Daybrayk;
public class AITriggerEvents : MonoBehaviour
{
    public UnityEventGameObject onTriggerEnter;
    public UnityEventGameObject onTriggerExit;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<AIBehaviour>() == null) return;
        if (onTriggerEnter != null) onTriggerEnter.Invoke(other.gameObject);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<AIBehaviour>() == null) return;
        onTriggerExit.TryInvoke(null);
    }
}
