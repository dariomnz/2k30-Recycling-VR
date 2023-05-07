using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

public class ScoreBoard : MonoBehaviour
{
    public static ScoreBoard Instance { get; private set; }
    public List<TextMeshProUGUI> labels;

    private int score = 0;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    public void UpdateScore(int diff)
    {   
        
        score += diff;
        if (score < 0)
            score = 0;
        if (score > 9999)
            score = 9999;

        foreach (var label in labels)
        {
            label.text = score.ToString("0000");
        }
    }
}
