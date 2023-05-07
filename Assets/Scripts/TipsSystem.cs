using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TipsSystem : MonoBehaviour
{
    public static TipsSystem Instance { get; private set; }

    public static Dictionary<Garbage.GarbageType, Color> GarbageColors = new Dictionary<Garbage.GarbageType, Color>(){
        {Garbage.GarbageType.None, new Color(1f,1f,1f)},
        {Garbage.GarbageType.Paper, new Color(0f, 0.38f, 0.659f)},
        {Garbage.GarbageType.Glass, new Color(0.106f, 0.584f, 0.196f)},
        {Garbage.GarbageType.Organic, new Color(0.49f, 0.239f, 0.098f)},
        {Garbage.GarbageType.Plastic, new Color(0.812f, 0.737f, 0f)},
    };

    public bool IsTipsActive = false;

    void Awake()
    {
        if (Instance != null && Instance != this)
            Destroy(this);
        else
            Instance = this;
    }

    public void ChangeTipsActive(bool newValue)
    {
        IsTipsActive = newValue;

        foreach (GameObject item in GameObject.FindGameObjectsWithTag("Garbage"))
        {
            Outline outline = item.GetComponent<Outline>();
            if (outline != null)
                outline.enabled = IsTipsActive;
        }
    }
}
