using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Garbage : MonoBehaviour
{
    public enum GarbageType
    {
        None,
        Paper,
        Glass,
        Organic,
        Plastic
    }

    public GarbageType garbageType = GarbageType.None;

    public GameObject destroyParticlePrefab;
    public AudioSource hitAudioSource;
    public List<AudioClip> randomHitSounds;

    private Rigidbody _rigidbody;
    private XRGrabInteractable grabInteractable;

    void Start()
    {
        Outline outline = GetComponent<Outline>();
        outline.OutlineColor = TipsSystem.GarbageColors[garbageType];
        outline.enabled = TipsSystem.Instance.IsTipsActive;

        grabInteractable = GetComponent<XRGrabInteractable>();
        _rigidbody = GetComponent<Rigidbody>();
        InvokeRepeating(nameof(CheckReSpawn), 5, 5);
    }


    void CheckReSpawn()
    {
        if (grabInteractable.isSelected)
            return;

        if (_rigidbody.velocity.magnitude < 0.001)
        {
            var particle = Instantiate(destroyParticlePrefab, transform.position, Quaternion.identity);
            Destroy(particle, 1);
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.impulse.magnitude > 1)
        {
            hitAudioSource.clip = randomHitSounds[Random.Range(0, randomHitSounds.Count)];
            hitAudioSource.Play();
        }
    }
}
