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
    ConfessionManager manager;

    private void Start()
    {
        manager = FindObjectOfType<ConfessionManager>();
        if (manager == null) Debug.LogError("No Confession Manager found in scene, please add one");
    }

    public void Interact()
    {
        if (manager.aiRef != null) manager.ConfessionStart(sitPosition, entryPosition);
    }
}
