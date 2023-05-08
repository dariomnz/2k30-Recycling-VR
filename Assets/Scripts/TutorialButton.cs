using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit;

public class TutorialButton : MonoBehaviour
{
    public GameObject tutorialCanvas;

    void Start()
    {
        var button = transform.GetComponent<Button>();
        button.onClick.AddListener(ButtonClicked);
    }

    void ButtonClicked()
    {
        tutorialCanvas?.SetActive(false);
        foreach (var item in GameObject.FindObjectsByType<XRInteractorLineVisual>(FindObjectsSortMode.None))
        {
            item.enabled = false;
        }
    }
}
