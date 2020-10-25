using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Daybrayk;
[RequireComponent(typeof(Collider))]
public class ConfessionTrigger : MonoBehaviour, IInteractable
{
    [SerializeField]
    Transform entryPosition;
    [SerializeField]
    Transform sitPosition;
    [SerializeField]
    ConfessionManager manager;

    public void Interact()
    {
        if (manager.aiRef != null) manager.ConfessionStart(sitPosition, entryPosition);
    }
}
