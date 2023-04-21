using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.UI;

public class ActivateUIRayInteractor : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{

    private XRUIInputModule InputModule => EventSystem.current.currentInputModule as XRUIInputModule;

    public void OnPointerEnter(PointerEventData eventData)
    {
        XRRayInteractor interactor = InputModule.GetInteractor(eventData.pointerId) as XRRayInteractor;

        interactor.GetComponent<XRInteractorLineVisual>().enabled = true;
        // interactor.xrController.SendHapticImpulse(0.25f, 0.25f);
        Debug.Log("OnPointerEnter");
        Debug.Log(interactor);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        XRRayInteractor interactor = InputModule.GetInteractor(eventData.pointerId) as XRRayInteractor;
        interactor.GetComponent<XRInteractorLineVisual>().enabled = false;
        // interactor.xrController.SendHapticImpulse(0.25f, 0.25f);
        Debug.Log("OnPointerExit");
        Debug.Log(interactor);
    }
}
