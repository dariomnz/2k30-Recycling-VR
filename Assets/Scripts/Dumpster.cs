using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dumpster : MonoBehaviour
{
    public Garbage.GarbageType type = Garbage.GarbageType.None;
    public GameObject particlesPrefab;
    public GameObject badParticlesPrefab;
    public Transform particlesPivot;
    

    void OnTriggerEnter(Collider other)
    {
        Garbage garbage = other.gameObject.GetComponent<Garbage>();
        if (garbage == null)
            return;
        GameObject particle = null;
        if (garbage.garbageType == type)
            particle = Instantiate(particlesPrefab, particlesPivot.position, Quaternion.identity);
        else
            particle = Instantiate(badParticlesPrefab, particlesPivot.position, Quaternion.identity);
        Destroy(particle, 1);
    }
}
