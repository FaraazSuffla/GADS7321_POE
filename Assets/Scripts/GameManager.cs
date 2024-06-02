using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public List<Pet> pets;
    public List<Owner> owners;

    public Text messageText;

    public void OnMatchButtonClick(Pet selectedPet, Owner selectedOwner)
    {
        if (MatchPetToOwner(selectedPet, selectedOwner))
        {
            messageText.text = "Match Successful!";
        }
        else
        {
            messageText.text = "Match Unsuccessful.";
        }
    }

    private bool MatchPetToOwner(Pet pet, Owner owner)
    {
        foreach (var trait in pet.traits)
        {
            if (owner.traits.Contains(trait))
            {
                return true;
            }
        }
        return false;
    }
}
