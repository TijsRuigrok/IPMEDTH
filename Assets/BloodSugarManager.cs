using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BloodSugarManager : MonoBehaviour
{
    [SerializeField] private TMP_Text bloodSugarText;

    private float bloodSugar = 4f;

    void Start()
    {
        UpdateBloodSugarText();
        StartCoroutine(StartEvent());
    }

    private IEnumerator StartEvent()
    {
        while(true)
        {
            yield return new WaitForSeconds(Random.Range(3, 6));
            AddBloodSugarEvent();
        }
    }

    private void AddBloodSugarEvent()
    {
        bloodSugar += Random.Range(1, 3);
        UpdateBloodSugarText();
    }

    private void UpdateBloodSugarText()
    {
        bloodSugarText.text = bloodSugar.ToString();
    }

    public void AddInsulin()
    {
        if(bloodSugar >= 1) bloodSugar -= 1;
        UpdateBloodSugarText();
    }
    
    public void AddGlucagon()
    {
        bloodSugar += 1;
        UpdateBloodSugarText();
    }

}
