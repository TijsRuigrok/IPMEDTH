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
    private float glucagonEventLevel = 0f;
    private float insulinBaseLevel = 0.2f;
    private float hormoneImpact = 0.001f;

    void Start()
    {
        bloodSugarText.UpdateBloodSugarText(bloodSugar);
        symptomManager.UpdateActiveSymptoms(bloodSugar);
        bloodSugarGauge.UpdatePosition(bloodSugar);
        StartCoroutine(GlucagonEvent());
        /*StartCoroutine(BloodSugarTrendDownwards());*/
    }

    private void Update()
    {
        bloodSugar += ((glucagonLevel + glucagonEventLevel) - (insulinLevel + insulinBaseLevel)) * hormoneImpact;
        if (bloodSugar < 0f) bloodSugar = 0f;
        else if (bloodSugar > 40f) bloodSugar = 40f;
        bloodSugarText.UpdateBloodSugarText(bloodSugar);
        symptomManager.UpdateActiveSymptoms(bloodSugar);
        bloodSugarGauge.UpdatePosition(bloodSugar);

    }

    public void UpdateGlucagonLevel(float newGlucagonLevel)
    {
        glucagonLevel = newGlucagonLevel;
    }
    
    public void UpdateInsulinLevel(float newInsulinLevel)
    {
        insulinLevel = newInsulinLevel;
    }

    private IEnumerator GlucagonEvent()
    {
        while(true)
        {
            yield return new WaitForSeconds(8);
            glucagonEventLevel += Random.Range(0.7f, 1f);
            insulinBaseLevel = 0f;
            yield return new WaitForSeconds(6);
            glucagonEventLevel = 0f;
            insulinBaseLevel = 0.2f;
        }
    }

    /*private IEnumerator BloodSugarTrendDownwards()
    {
        while(true)
        {
            yield return new WaitForSeconds(1f);
            bloodSugar -= 0.25f;
        }
    }*/
}
