using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using Daybrayk.Properties;

public class WarTable : MonoBehaviour, IInteractable
{
    [Header("Setup")]
    public Image secretsBar;
    public GameObject menu;

    [Header("Game Variables")]
    public int targetSecrets;
    [SerializeField] private IntReference currentSecrets;

    public void UpdateSecrets()
    {
        //Calc fill
        float fill = (float)currentSecrets.Value / (float)targetSecrets;
        secretsBar.fillAmount = fill;

        if(currentSecrets.Value == 10)
        {
            menu.SetActive(true);
        }
    }

    public void Interact()
    {
        UpdateSecrets();
    }
}