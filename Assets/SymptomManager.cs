using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SymptomManager : MonoBehaviour
{
    [SerializeField] private List<Symptom> symptoms;
    [SerializeField] private GameObject list;
    [SerializeField] private SymptomListItem listItem;
    [SerializeField] private Image personImage;
    [SerializeField] private Sprite healthyPersonImage;

    public void UpdateActiveSymptoms(float currentBloodSugar)
    {
        foreach (Transform item in list.transform) Destroy(item.gameObject);

        foreach (Symptom symptom in symptoms)
        {
            if ((symptom.bloodSugarLevel >= 8) && (currentBloodSugar >= symptom.bloodSugarLevel) || 
                (symptom.bloodSugarLevel <= 4) && (currentBloodSugar <= symptom.bloodSugarLevel))
            {
                SymptomListItem newListItem = Instantiate(listItem);
                newListItem.UpdateNameText(symptom.symptonName);
                newListItem.transform.SetParent(list.transform);
                personImage.sprite = symptom.image;
            }

            else if (currentBloodSugar <= 11 && currentBloodSugar >= 4) personImage.sprite = healthyPersonImage;
        }
    }
}
