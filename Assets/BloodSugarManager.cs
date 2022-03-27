using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodSugarManager : MonoBehaviour
{
    [SerializeField] private BloodSugarText bloodSugarText;
    [SerializeField] private SymptomManager symptomManager;
    [SerializeField] private BloodSugarGauge bloodSugarGauge;
    
    public float bloodSugar = 6f;
    private float insulinLevel = 0f;
    private float glucagonLevel = 0f;
    private float hormoneImpact = 0.001f;

    void Start()
    {
        bloodSugarText.UpdateBloodSugarText(bloodSugar);
        symptomManager.UpdateActiveSymptoms(bloodSugar);
        bloodSugarGauge.UpdatePosition(bloodSugar);
        /*StartCoroutine(StartEvent());*/
        StartCoroutine(BloodSugarTrendDownwards());
    }

    private void Update()
    {
        bloodSugar += (glucagonLevel - insulinLevel) * hormoneImpact;
        if (bloodSugar < 0) bloodSugar = 0;
    }

    public void UpdateGlucagonLevel(float newGlucagonLevel)
    {
        glucagonLevel = newGlucagonLevel;
    }
    
    public void UpdateInsulinLevel(float newInsulinLevel)
    {
        insulinLevel = newInsulinLevel;
    }

    private IEnumerator StartEvent()
    {
        while(true)
        {
            yield return new WaitForSeconds(Random.Range(8, 8));
            AddBloodSugarEvent();
        }
    }

    private void AddBloodSugarEvent()
    {
        bloodSugar += Random.Range(5, 10);
        if (bloodSugar > 30) bloodSugar = 30;

        bloodSugarText.UpdateBloodSugarText(bloodSugar);
        symptomManager.UpdateActiveSymptoms(bloodSugar);
        bloodSugarGauge.UpdatePosition(bloodSugar);
    }

    private IEnumerator BloodSugarTrendDownwards()
    {
        while(true)
        {
            yield return new WaitForSeconds(1f);
            bloodSugar -= 0.25f;
            bloodSugarText.UpdateBloodSugarText(bloodSugar);
            symptomManager.UpdateActiveSymptoms(bloodSugar);
            bloodSugarGauge.UpdatePosition(bloodSugar);
        }
    }
}
