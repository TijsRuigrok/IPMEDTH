using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BloodSugarText : MonoBehaviour
{
    [SerializeField] private TMP_Text bloodSugarText;
    [SerializeField] private TMP_Text bloodSugarDifferenceText;

    float bloodSugar;

    public void UpdateBloodSugarText(float updatedBloodSugar)
    {
        bloodSugar = float.Parse(bloodSugarText.text);
        ShowDifference(updatedBloodSugar);
        StartCoroutine(UpdateBloodSugarTextAnimation(updatedBloodSugar));
    }

    private IEnumerator UpdateBloodSugarTextAnimation(float updatedBloodSugar)
    {
        float tempBloodSugar = bloodSugar;

        while(tempBloodSugar != updatedBloodSugar)
        {
            yield return new WaitForSeconds(0.3f);

            if (updatedBloodSugar > tempBloodSugar) tempBloodSugar += 1;
            else if (updatedBloodSugar < tempBloodSugar) tempBloodSugar -= 1;
            bloodSugarText.text = tempBloodSugar.ToString();
        }
    }

    private void ShowDifference(float updatedBloodSugar)
    {
        float difference = updatedBloodSugar - bloodSugar;
        if(difference > 0) bloodSugarDifferenceText.text = "+" + difference.ToString();
        else bloodSugarDifferenceText.text = difference.ToString();
    }
}
