using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BloodSugarGauge : MonoBehaviour
{
    [SerializeField] private Slider slider;

    [SerializeField] private float centerBloodSugar = 6f;
    [SerializeField] private float endBloodSugar = 40f;

    public void UpdatePosition(float bloodSugar)
    {
        slider.value = CalculatePosition(bloodSugar);
    }

    private float CalculatePosition(float bloodSugar)
    {
        if (bloodSugar <= centerBloodSugar) return bloodSugar / (2f * centerBloodSugar);
        else return 0.5f * (bloodSugar - endBloodSugar) / (endBloodSugar - centerBloodSugar) + 1f;
    }
}
