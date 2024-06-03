using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComputerPanelController : MonoBehaviour, Interactable
{
    public GameObject computerPanel;
    public void Interact()
    {
        Debug.Log("Interacting with computer panel");

        if (computerPanel.activeSelf)
        {
            computerPanel.SetActive(false);
        }
        else
        {
            computerPanel.SetActive(true);
        }
    }

    
}
