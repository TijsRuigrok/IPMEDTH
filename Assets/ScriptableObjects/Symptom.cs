using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Symptoms", menuName = "ScriptableObjects/Symptom", order = 1)]
public class Symptom : ScriptableObject
{
    public string symptonName;
    public float bloodSugarLevel;
    public Sprite image;
}
