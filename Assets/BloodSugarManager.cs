using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodSugarManager : MonoBehaviour
{
    [SerializeField] private BloodSugarText bloodSugarText;
    [SerializeField] private SymptomManager symptomManager;
    [SerializeField] private BloodSugarGauge bloodSugarGauge;

    [SerializeField] private Apple applePrefab;
    [SerializeField] private Transform canvasTransform;

    [SerializeField] private Transform appleSpawnPoint;

    public float bloodSugar = 17f;
    private float insulinLevel = 0f;
    private float glucagonLevel = 0f;
    private float glucagonEventLevel = 0f;
    private float insulinBaseLevel = 0.5f;
    private float hormoneImpact = 0.015f;

    void Start()
    {
        bloodSugarText.UpdateBloodSugarText(bloodSugar);
        symptomManager.UpdateActiveSymptoms(bloodSugar);
        bloodSugarGauge.UpdatePosition(bloodSugar);
        StartCoroutine(GlucagonEvent());
    }

    void FixedUpdate()
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
            Apple newApple = Instantiate(applePrefab);
            newApple.transform.SetParent(canvasTransform);
            newApple.transform.position = appleSpawnPoint.position;
            float randomNumber = UnityEngine.Random.Range(6f, 8f);
            newApple.UpdateText($"+{Math.Round(randomNumber, 1) }");
            /*glucagonEventLevel += Random.Range(0.7f, 1f);*/
            /*insulinBaseLevel = 0f;*/
            yield return new WaitForSeconds(2);
            bloodSugar += randomNumber;
            /*glucagonEventLevel = 0f;
            insulinBaseLevel = 0.2f;*/
        }
    }
}
