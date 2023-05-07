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

    public Dictionary<GarbageType, Color> GarbageColors = new Dictionary<GarbageType, Color>(){
        {GarbageType.None, new Color(1f,1f,1f)},
        {GarbageType.Paper, new Color(0f, 0.38f, 0.659f)},
        {GarbageType.Glass, new Color(0.106f, 0.584f, 0.196f)},
        {GarbageType.Organic, new Color(0.49f, 0.239f, 0.098f)},
        {GarbageType.Plastic, new Color(0.812f, 0.737f, 0f)},
    };

    public GarbageType garbageType = GarbageType.None;

    void Start()
    {
        Outline outline = GetComponent<Outline>();
        outline.OutlineColor = GarbageColors[garbageType];
        outline.enabled = TipsSystem.Instance.IsTipsActive;
    }

}
