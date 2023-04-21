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
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        XRRayInteractor interactor = InputModule.GetInteractor(eventData.pointerId) as XRRayInteractor;
        interactor.GetComponent<XRInteractorLineVisual>().enabled = false;
    }
}
