using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BloodSugarText : MonoBehaviour
{
    [SerializeField] private TMP_Text bloodSugarText;
    [SerializeField] private TMP_Text bloodSugarDifferenceText;

    [SerializeField] private Color red = new Color(200, 0, 0);
    [SerializeField] private Color green = new Color(0, 200, 0);

    private float bloodSugar;


    public void UpdateBloodSugarText(float updatedBloodSugar)
    {
        bloodSugar = float.Parse(bloodSugarText.text);
        /*ShowDifference(updatedBloodSugar);*/
        /*StartCoroutine(UpdateBloodSugarTextAnimation(updatedBloodSugar));*/
        
        bloodSugarText.text = Math.Round(updatedBloodSugar, 1).ToString();
    }

   /* private IEnumerator UpdateBloodSugarTextAnimation(float updatedBloodSugar)
    {
        float tempBloodSugar = bloodSugar;

        while(tempBloodSugar != updatedBloodSugar)
        {
            yield return new WaitForSeconds(0.1f);

            if (updatedBloodSugar > tempBloodSugar) tempBloodSugar += 1;
            else if (updatedBloodSugar < tempBloodSugar) tempBloodSugar -= 1;
            
            bloodSugarText.text = tempBloodSugar.ToString();
        }
    }*/

    private void ShowDifference(float updatedBloodSugar)
    {
        float difference = updatedBloodSugar - bloodSugar;
        if (difference > 0)
        {
            bloodSugarDifferenceText.text = "+" + Math.Round(difference, 1).ToString();
            bloodSugarDifferenceText.color = green;
        }
        else
        {
            bloodSugarDifferenceText.text = Math.Round(difference, 1).ToString();
            bloodSugarDifferenceText.color = red;
        }
    }
}
