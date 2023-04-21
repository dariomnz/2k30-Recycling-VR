using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class HandHider : MonoBehaviour
{
    public GameObject handObject = null;

    private HandPhysics handPhysics = null;
    private XRDirectInteractor interactor = null;

    private void Awake()
    {
        handPhysics = handObject.GetComponent<HandPhysics>();
        interactor = GetComponent<XRDirectInteractor>();
    }

    private void OnEnable()
    {
        interactor.selectEntered.AddListener(Hide);
        interactor.selectExited.AddListener(Show);
    }

    private void OnDisable()
    {
        interactor.selectEntered.RemoveListener(Hide);
        interactor.selectExited.RemoveListener(Show);
    }

    private void Show(SelectExitEventArgs interactable)
    {
        handPhysics.TeleportToTarget();
        Invoke(nameof(DelayShow), 0.2f);
    }

    private void Hide(SelectEnterEventArgs interactable)
    {
        handObject.GetComponent<Collider>().enabled = false;
    }

    private void DelayShow()
    {
        handObject.GetComponent<Collider>().enabled = true;
    }
}
