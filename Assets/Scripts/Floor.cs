using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floor : MonoBehaviour
{
    public GameObject destroyParticlePrefab;
    void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Garbage"))
        {
            StartCoroutine(DelayDestroy(1f, collider.gameObject));
        }
    }

    IEnumerator DelayDestroy(float delayTime, GameObject gameObject)
    {
        yield return new WaitForSeconds(delayTime);
        var particle = Instantiate(destroyParticlePrefab, gameObject.transform.position, Quaternion.identity);
        Destroy(particle, 1);
        Destroy(gameObject);
    }
}
