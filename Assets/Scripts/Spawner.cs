using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public float radius = 0.4f;
    public List<GameObject> Spawnable;
    [SerializeField]
    private float SpawnsPerSecond = 1;

    void Start()
    {
        InvokeRepeating("Spawn", 0, 1 / SpawnsPerSecond);
    }

    void Spawn()
    {
        GameObject obj = Spawnable[Random.Range(0, Spawnable.Count)];
        Vector3 randomPos = Random.insideUnitSphere * radius;
        randomPos += transform.position;
        var instance = Instantiate(obj, randomPos, Random.rotation);

    }

    public void ChangeSpawnSpeed(float newSpawnsPerSec)
    {
        SpawnsPerSecond = newSpawnsPerSec;
        CancelInvoke("Spawn");
        InvokeRepeating("Spawn", 1f / SpawnsPerSecond, 1f / SpawnsPerSecond);
    }
}
