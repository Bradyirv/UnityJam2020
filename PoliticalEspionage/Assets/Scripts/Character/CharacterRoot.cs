using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

using UnityEngine.SceneManagement;
public class CharacterRoot : MonoBehaviour
{
    public CharacterMovement movement { get; private set; }
    public CharacterInteraction interaction { get; private set; }
    public PlayerInput input { get; private set; }

    private void Start()
    {
        movement = GetComponent<CharacterMovement>();
        interaction = GetComponent<CharacterInteraction>();
        input = GetComponent<PlayerInput>();
    }

    public void ResetGame()
    {
        SceneManager.LoadScene(0);
    }
}
