using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class HandImpulse : MonoBehaviour
{
    public float Impulse = 2f;
    private XRGrabInteractable grabInteractable;
    private Rigidbody _rigidbody;

    [HideInInspector]
    public bool IsSlingShot = false;

    void Start()
    {
        grabInteractable = GetComponent<XRGrabInteractable>();
        _rigidbody = GetComponent<Rigidbody>();

        grabInteractable.selectExited.AddListener(OnReleased);
    }

    public void OnReleased(SelectExitEventArgs args)
    {
        if (!IsSlingShot)
            Invoke(nameof(ApplyImpulse), 0.05f);
    }

    void ApplyImpulse()
    {
        if (_rigidbody.velocity.magnitude > 1)
        {
            _rigidbody.AddForce(_rigidbody.velocity.normalized * Impulse, ForceMode.Impulse);
            GetComponent<AudioSource>()?.Play();
        }
    }
}
