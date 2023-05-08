using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyArea : MonoBehaviour
{
    AudioSource audioSource;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Garbage"))
        {
            Destroy(other.gameObject);

            audioSource.pitch = Random.Range(0.8f, 1.2f);
            audioSource.Play();
        }
    }
}
