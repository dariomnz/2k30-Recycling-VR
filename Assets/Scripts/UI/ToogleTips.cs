using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ToogleTips : MonoBehaviour
{

    void Start()
    {
        GetComponent<Toggle>().onValueChanged.AddListener(ChangeTips);
    }

    void ChangeTips(bool newValue)
    {
        TipsSystem.Instance.ChangeTipsActive(newValue);
    }
}
