using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Garbage : MonoBehaviour
{
    public enum GarbageType
    {
        None,
        Paper,
        Glass,
        Organic,
        Plastic
    }

    public GarbageType garbageType = GarbageType.None;

    void Start()
    {
        Outline outline = GetComponent<Outline>();
        outline.OutlineColor = TipsSystem.GarbageColors[garbageType];
        outline.enabled = TipsSystem.Instance.IsTipsActive;
    }

}
