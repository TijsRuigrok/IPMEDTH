using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    [SerializeField] private TMP_Text healthPointsText;
    [SerializeField] private BloodSugarManager bloodSugarManager;
    
    private float healthPoints = 100f;

    private void Start()
    {
        StartCoroutine(RecurrentlyUpdateHealthPoints());
    }

    private IEnumerator RecurrentlyUpdateHealthPoints()
    {
        while(true)
        {
            yield return new WaitForSeconds(2f);
            UpdateHealthPoints(bloodSugarManager.bloodSugar);
        }
    }

    public void UpdateHealthPoints(float bloodSugar)
    {
        if (bloodSugar > 11 && bloodSugar <= 17) healthPoints -= 1;
        else if (bloodSugar >= 17 && bloodSugar <= 25) healthPoints -= 2;
        else if (bloodSugar >= 25 && bloodSugar <= 30) healthPoints -= 5;
        else if (bloodSugar >= 30 && bloodSugar <= 40) healthPoints -= 10;
        else if (bloodSugar >= 40) healthPoints -= 15;

        else if (bloodSugar < 4 && bloodSugar >= 2) healthPoints -= 1;
        else if (bloodSugar <= 2 && bloodSugar >= 0) healthPoints -= 5;
        else if (bloodSugar == 0) healthPoints -= 10;

        else if (bloodSugar < 0) healthPoints = 0;

        healthPointsText.text = healthPoints.ToString();
    }
}
