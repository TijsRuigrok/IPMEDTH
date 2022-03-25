using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SymptomListItem : MonoBehaviour
{
    [SerializeField] private TMP_Text symptomNameText;
    
    public void UpdateNameText(string name)
    {
        symptomNameText.text = name;
    }
}
