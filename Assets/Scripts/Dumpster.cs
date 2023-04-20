using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dumpster : MonoBehaviour
{
    public GameObject particlesPrefab;
    public Transform particlesPivot;

    void OnTriggerEnter(Collider other)
    {   
        var particle = Instantiate(particlesPrefab,particlesPivot.position,Quaternion.identity);
        Destroy(particle,1);
    }
}
