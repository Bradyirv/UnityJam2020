using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using Daybrayk.Properties;

public class WarTable : MonoBehaviour, IInteractable
{
    [Header("Setup")]
    public Image secretsBar;

    [Header("Game Variables")]
    public int targetSecrets;
    [SerializeField] private IntReference currentSecrets;

    public void UpdateSecrets()
    {
        //Calc fill
        float fill = (float)currentSecrets.Value / (float)targetSecrets;
        secretsBar.fillAmount = fill;
    }

    public void Interact()
    {
        UpdateSecrets();
    }
}