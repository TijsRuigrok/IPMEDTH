using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GlucagonSlider : MonoBehaviour
{
    [SerializeField] private BloodSugarManager bloodSugarManager;
    [SerializeField] private Slider slider;

    private void Start()
    {
        slider.onValueChanged.AddListener(delegate 
        { 
            bloodSugarManager.UpdateGlucagonLevel(slider.value); 
        });
    }
}
