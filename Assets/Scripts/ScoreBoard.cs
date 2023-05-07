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
            Destroy(this);
        else
            Instance = this;
    }

    public void UpdateScore(int diff)
    {
        int preScore = score;
        score += diff;
        if (score < 0)
            score = 0;
        if (score > 9999)
            score = 9999;

        LeanTween.cancel(gameObject);
        LeanTween.value(gameObject, preScore, score, 0.5f).setOnUpdate(SetText);
    }

    void SetText(float val)
    {
        string text = val.ToString("0000");
        foreach (var label in labels)
            label.text = text;
    }
}
