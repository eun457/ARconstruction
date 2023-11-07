using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SldierBar : MonoBehaviour
{
    [SerializeField] private Slider slider;
    void Start()
    {
        slider.onValueChanged.AddListener(OnSliderValueChanged);
    }

    private void OnSliderValueChanged(float value)
    {
        if (value == 0)
        {
            Debug.Log(" ��");
        }
        else if (value == 1)
        {
            Debug.Log(" ��2");
        }
        else if (value == 2)
        {
            Debug.Log(" ��3");
        }
        else if (value == 3)
        {
            Debug.Log(" ��4");
        }
        else
        {

        }

    }


}
