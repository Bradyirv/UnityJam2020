using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConfessionCurtain : MonoBehaviour
{
    public Transform Curtain;
    private Vector3 targetScale;
    private Vector3 originalScale;
    public float speed = 1.5f;
    public float targetScaleX;

    bool Open;
    bool moveToOriginalPosition = false;

    public float stayOpen = 1.5f;
    public float timeOpen = 0;

    private void Start()
    {
        originalScale = Curtain.localScale;
        targetScale = new Vector3(targetScaleX, Curtain.localScale.y, Curtain.localScale.z);
    }

    public void OpenCurtain()
    {
        Open = true;
    }

    private void Update()
    {
        if (Open)
        {
            if (Curtain.localScale.x < targetScaleX)
            {
                if (timeOpen >= stayOpen)
                {
                    timeOpen = 0;
                    Open = false;
                    moveToOriginalPosition = true;
                }
                else
                {
                    timeOpen += Time.deltaTime;
                }
            }
            else
            {
                Curtain.localScale += new Vector3(-0.1f, 0, 0);
            }
        }
        else if (moveToOriginalPosition)
        {
            if (Curtain.localScale.x > originalScale.x)
            {
                moveToOriginalPosition = false;
            }
            else
            {
                Curtain.localScale += new Vector3(0.1f, 0, 0);
            }
        }
    }
}
