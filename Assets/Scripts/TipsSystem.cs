using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TipsSystem : MonoBehaviour
{
    public static TipsSystem Instance { get; private set; }

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
