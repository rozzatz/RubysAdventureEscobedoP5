using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class healyhbar : MonoBehaviour
{
    public static healyhbar instance { get; private set; }
    public Image mask;
    float originalsize;
    // Start is called before the first frame update

    private void Awake()
    {
        instance = this; 
    }
    void Start()
    {
        originalsize = mask.rectTransform.rect.width;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SetValue(float value)
    {
        mask.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, originalsize * value);
    }
}

public class UIHealthBar
{
}