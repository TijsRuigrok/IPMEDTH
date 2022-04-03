using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Apple : MonoBehaviour
{
    [SerializeField] private Image image;
    [SerializeField] TMP_Text text;
    
    [SerializeField] private Transform tr;
    [SerializeField] private float endPos = 1;
    
    private Color imageColor;
    private bool fadeOut = false;

    void Start()
    {
        imageColor = image.color;
    }

    void FixedUpdate()
    {
        if (tr.position.x >= endPos) tr.Translate(-Time.deltaTime * 100, 0, 0);
        else fadeOut = true;

        if(fadeOut)
        {
            imageColor.a -= 0.03f;
            image.color = imageColor;
            text.color = imageColor;

            if (imageColor.a <= 0)
            {
                Destroy(gameObject);
            }
        }
        
    }

    public void UpdateText(string updatedText)
    {
        text.text = updatedText;
    }
}
