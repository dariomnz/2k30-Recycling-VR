using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class HandImpulse : MonoBehaviour
{
    public float Impulse = 2f;
    private XRGrabInteractable grabInteractable;

    void Start()
    {
        grabInteractable = GetComponent<XRGrabInteractable>();

        grabInteractable.selectExited.AddListener(OnReleased);
    }


    public void OnReleased(SelectExitEventArgs args)
    {
        Invoke(nameof(ApplyImpulse), 0.05f);
    }
    void ApplyImpulse()
    {
        var rigidbody = GetComponent<Rigidbody>();
        if (rigidbody.velocity.magnitude > 1)
            rigidbody.AddForce(rigidbody.velocity.normalized * Impulse, ForceMode.Impulse);
    }
}
