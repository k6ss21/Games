using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimBar : MonoBehaviour
{
    public Slider slider;

    public void SetMaxTime(float maxTime)
    {
        slider.maxValue = maxTime;
        slider.value = maxTime;
    }

    public void SetTime(float time)
    {
        slider.value = time;
    }
}
