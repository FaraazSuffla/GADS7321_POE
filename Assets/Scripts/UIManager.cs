using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class UIManager : MonoBehaviour
{
    public GameManager gameManager;
    public Dropdown petDropdown;
    public Dropdown ownerDropdown;

    public Text petNameText;
    public Text petTraitsText;
    public Text ownerNameText;
    public Text ownerTraitsText;

    private Pet selectedPet;
    private Owner selectedOwner;

    private void Start()
    {
        UpdateDropdowns();
    }

    public void OnPetSelected(int index)
    {
        selectedPet = gameManager.pets[index];
        UpdatePetDetails(selectedPet);
    }

    public void OnOwnerSelected(int index)
    {
        selectedOwner = gameManager.owners[index];
        UpdateOwnerDetails(selectedOwner);
    }

    public void OnMatchButtonClick()
    {
        // Ensure selectedPet and selectedOwner are not null
        if (selectedPet != null && selectedOwner != null)
        {
            gameManager.OnMatchButtonClick(selectedPet, selectedOwner);
        }
        else
        {
            Debug.LogError("Selected pet or owner is null!");
        }
    }

    private void UpdateDropdowns()
    {
        if (gameManager == null)
        {
            Debug.LogError("GameManager is not assigned to UIManager!");
            return;
        }

        if (gameManager.pets == null)
        {
            Debug.LogError("GameManager.pets is null!");
            return;
        }

        if (gameManager.owners == null)
        {
            Debug.LogError("GameManager.owners is null!");
            return;
        }

       
    }


    private void UpdatePetDetails(Pet pet)
    {
        petNameText.text = "Name: " + pet.petName;
        petTraitsText.text = "Traits: " + string.Join(", ", pet.traits);
    }

    private void UpdateOwnerDetails(Owner owner)
    {
        ownerNameText.text = "Name: " + owner.ownerName;
        ownerTraitsText.text = "Traits: " + string.Join(", ", owner.traits);
    }
}
