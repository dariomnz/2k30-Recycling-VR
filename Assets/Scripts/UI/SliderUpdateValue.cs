using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class SliderUpdateValue : MonoBehaviour
{
    public TextMeshProUGUI TextValue;

    void Start()
    {
        GetComponent<Slider>().onValueChanged.AddListener(OnValueChanged);
    }

    void OnValueChanged(float val)
    {
        TextValue.text = val.ToString("0.00");
    }
}
