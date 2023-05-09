using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class DisableGrabOnSelect : MonoBehaviour
{
    private XRGrabInteractable grabInteractable;
    private string leftHand = "LeftHand";
    private string rightHand = "RightHand";
    // Start is called before the first frame update
    void Start()
    {
        grabInteractable = GetComponent<XRGrabInteractable>();

        grabInteractable.selectEntered.AddListener(OnSelected);
        grabInteractable.selectExited.AddListener(OnReleased);
    }

    void OnSelected(SelectEnterEventArgs args)
    {
        if (args.interactorObject.transform.parent.name.Contains(leftHand))
            grabInteractable.interactionLayers = InteractionLayerMask.GetMask(new string[] { leftHand });
        else
            grabInteractable.interactionLayers = InteractionLayerMask.GetMask(new string[] { rightHand });
    }

    void OnReleased(SelectExitEventArgs args)
    {
        grabInteractable.interactionLayers = InteractionLayerMask.GetMask(new string[] { "Default" });
    }
}
