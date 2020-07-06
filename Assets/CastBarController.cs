using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CastBarController : MonoBehaviour
{
    public Slider slider;
    public bool casting;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void OnCastStarted(float maxValue)
    {
        slider.maxValue = maxValue;
        casting = true;
    }

    public void OnCastFinished()
    {
        casting = false;
        slider.value = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (casting)
        {
            UpdateCastbar();
        }
    }

    void UpdateCastbar()
    {
        slider.value += Time.deltaTime;
    }
}
