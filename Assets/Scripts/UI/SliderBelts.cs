using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderBelts : MonoBehaviour
{
    public List<ConveyorBelt> Belts;
    
    void Start()
    {
        GetComponent<Slider>().onValueChanged.AddListener(OnValueChanged);
    }

    void OnValueChanged(float val)
    {
        foreach (ConveyorBelt belt in Belts)
        {
            belt.Speed = val;
        }
    }
}
