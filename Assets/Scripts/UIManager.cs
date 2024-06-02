using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text ownerNameText;
    public Text petNameText;
    public Text ownerTraitsText;
    public Text petTraitsText;

    public Owner ownerData;
    public Pet petData;

    void Start()
    {
        UpdateUI();
    }

    void UpdateUI()
    {
        ownerNameText.text = "Owner Name: " + ownerData.ownerName;
        petNameText.text = "Pet Name: " + petData.petName;

        ownerTraitsText.text = "Owner Traits:\n";
        foreach (string trait in ownerData.traits)
        {
            ownerTraitsText.text += "- " + trait + "\n";
        }

        petTraitsText.text = "Pet Traits:\n";
        foreach (string trait in petData.traits)
        {
            petTraitsText.text += "- " + trait + "\n";
        }
    }
}
