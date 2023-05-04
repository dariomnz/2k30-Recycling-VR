using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class SlingShotHead : MonoBehaviour
{
    public float force = 5.0f;
    public Transform SlingShotAim;
    public Transform HeadInitTransform;
    private GameObject throwable = null;

    void Update()
    {
        if (throwable != null)
        {
            transform.position = throwable.transform.position;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (!gameObject.GetComponentInParent<XRGrabInteractable>().isSelected)
            return;

        XRGrabInteractable grabInteractable = other.gameObject.GetComponent<XRGrabInteractable>();
        if (grabInteractable != null && grabInteractable.isSelected)
        {
            throwable = other.gameObject;
            other.gameObject.GetComponent<XRGrabInteractable>()?.selectExited.AddListener(Throw);
        }
    }

    void Throw(SelectExitEventArgs args)
    {
        args.interactorObject.transform.gameObject.GetComponent<XRGrabInteractable>()?.selectExited.RemoveListener(Throw);
        Rigidbody rigidbody = args.interactableObject.transform.gameObject.GetComponent<Rigidbody>();
        Vector3 direction = SlingShotAim.position - rigidbody.transform.position;
        float distance = direction.magnitude;
        rigidbody.AddForce(direction.normalized * distance * force, ForceMode.Impulse);

        throwable = null;
        transform.position = HeadInitTransform.position;
        transform.rotation = HeadInitTransform.rotation;

        args.interactableObject.transform.gameObject.layer = LayerMask.NameToLayer("Throwable");

        StartCoroutine(ChangeLayerDefault(0.2f, args.interactableObject.transform.gameObject));
    }

    IEnumerator ChangeLayerDefault(float delayTime, GameObject gameObject)
    {
        yield return new WaitForSeconds(delayTime);

        gameObject.layer = LayerMask.NameToLayer("Default");
    }
}
