using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorchWarRoom : MonoBehaviour, IInteractable
{
    public Transform SecretWall;
    public Transform targetPosition;
    public Vector3 originalPosition;
    public float speed = 1f;

    bool isOpen;
    bool moveToOriginalPosition = false;

    public float stayOpen = 2f;
    public float timeOpen = 0;

    public void Interact()
    {
        if (isOpen == false) isOpen = true;
    }

    private void Start()
    {
        originalPosition = SecretWall.position;
    }

    private void FixedUpdate()
    {
        if(isOpen)
        {
            if(Vector3.Distance(SecretWall.position, targetPosition.position) < 0.5f)
            {
                if (timeOpen >= stayOpen)
                {
                    timeOpen = 0;
                    isOpen = false;
                    moveToOriginalPosition = true;
                }
                else
                {
                    timeOpen += Time.deltaTime;
                }
            }
            else
            {
                SecretWall.position = Vector3.Lerp(SecretWall.position, targetPosition.position, Time.deltaTime * speed);
            }
        }
        else if(moveToOriginalPosition)
        {
            if (Vector3.Distance(SecretWall.position, originalPosition) <= 0.01f)
            {
                moveToOriginalPosition = false;
            }
            else
            {
                SecretWall.position = Vector3.Lerp(SecretWall.position, originalPosition, Time.deltaTime * speed);
            }
        }
    }
}
