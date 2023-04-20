using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderSpawner : MonoBehaviour
{
    public Spawner Spawner;

    void Start()
    {
        GetComponent<Slider>().onValueChanged.AddListener(OnValueChanged);
    }

    void OnValueChanged(float val)
    {
        Spawner.ChangeSpawnSpeed(val);
    }
}
