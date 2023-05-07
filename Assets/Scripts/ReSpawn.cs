using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ReSpawn : MonoBehaviour
{
    public GameObject particlesPrefab;

    private Rigidbody _rigidbody;
    private XRGrabInteractable grabInteractable;

    private Vector3 initPos;
    private Quaternion initRot;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        grabInteractable = GetComponent<XRGrabInteractable>();
        initPos = transform.position;
        initRot = transform.rotation;
        InvokeRepeating(nameof(CheckReSpawn), 0, 5);
    }

    void CheckReSpawn()
    {
        // foreach (var item in GameObject.FindGameObjectsWithTag("SlingShot"))
        // {
        //     Debug.Log(item.ToString());
        // }
        // foreach (var item in Physics.OverlapSphere(initPos, 0.5f))
        // {
        //     Debug.Log(item.ToString());
        // }
        Collider[] hitColliders = Physics.OverlapSphere(initPos, 0.5f);
        foreach (var hitCollider in hitColliders)
        {
            // Debug.Log(hitCollider.CompareTag("SlingShot"));
            if (hitCollider.CompareTag("SlingShot"))
                return;
        }

        if (grabInteractable.isSelected)
            return;
        if (_rigidbody.velocity.magnitude < 1)
        {
            var particle = Instantiate(particlesPrefab, transform.position, Quaternion.identity);
            Destroy(particle, 1);
            transform.position = initPos;
            transform.rotation = initRot;
        }

    }
}
