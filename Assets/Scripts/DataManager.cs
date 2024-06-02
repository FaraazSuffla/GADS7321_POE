using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public List<Owner> ownerDataList;
    public List<Pet> petDataList;

    void Start()
    {
        // Load owner data from Scriptable Objects
        ownerDataList = new List<Owner>(Resources.LoadAll<Owner>(""));

        // Load pet data from Scriptable Objects
        petDataList = new List<Pet>(Resources.LoadAll<Pet>(""));

        if (ownerDataList.Count == 0 || petDataList.Count == 0)
        {
            Debug.LogError("Owner data or pet data not found.");
            return;
        }

        // Select random owner and pet
        Owner selectedOwner = ownerDataList[Random.Range(0, ownerDataList.Count)];
        Pet selectedPet = petDataList[Random.Range(0, petDataList.Count)];

        // Pass data to UIManager
        UIManager uiManager = GetComponent<UIManager>();
        uiManager.ownerData = selectedOwner;
        uiManager.petData = selectedPet;

        // Update UI
        uiManager.UpdateUI();
    }
}
