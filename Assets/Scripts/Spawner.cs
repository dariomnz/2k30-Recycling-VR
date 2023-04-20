using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject Spawnable;
    [SerializeField]
    private float SpawnsPerSecond = 1;

    void Start()
    {
        InvokeRepeating("Spawn", 0, 1 / SpawnsPerSecond);
    }

    void Spawn()
    {
        var instance = Instantiate(Spawnable, transform.position, Quaternion.identity);
    }

    public void ChangeSpawnSpeed(float newSpawnsPerSec)
    {
        SpawnsPerSecond = newSpawnsPerSec;
        CancelInvoke("Spawn");
        InvokeRepeating("Spawn", 1f / SpawnsPerSecond, 1f / SpawnsPerSecond);
    }
}
