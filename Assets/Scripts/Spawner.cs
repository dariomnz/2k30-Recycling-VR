using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject Spawnable;
    public float TimeIntervals = 1;

    void Start()
    {
        InvokeRepeating("Spawn", 0, TimeIntervals);
    }

    void Spawn()
    {
        var instance = Instantiate(Spawnable, transform.position, Quaternion.identity);
    }
}
