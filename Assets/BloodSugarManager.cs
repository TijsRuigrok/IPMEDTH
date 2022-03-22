using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodSugarManager : MonoBehaviour
{
    [SerializeField] private BloodSugarText bloodSugarText;
    
    [SerializeField] private float insulinDose = 2f;
    [SerializeField] private float glucagonDose = 2f;
    
    private float bloodSugar = 4f;

    void Start()
    {
        bloodSugarText.UpdateBloodSugarText(bloodSugar);
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
        bloodSugarText.UpdateBloodSugarText(bloodSugar);
    }

    public void AddInsulin()
    {
        if(bloodSugar >= insulinDose) bloodSugar -= insulinDose;
        bloodSugarText.UpdateBloodSugarText(bloodSugar);
    }

    public void AddGlucagon()
    {
        bloodSugar += glucagonDose;
        bloodSugarText.UpdateBloodSugarText(bloodSugar);
    }
}
