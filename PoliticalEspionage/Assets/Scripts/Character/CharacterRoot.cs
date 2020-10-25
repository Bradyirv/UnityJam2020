using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterRoot : MonoBehaviour
{
    CharacterMovement movement;
    CharacterInteraction interaction;
    private void Start()
    {
        movement = GetComponent<CharacterMovement>();
        interaction = GetComponent<CharacterInteraction>();
    }
}
