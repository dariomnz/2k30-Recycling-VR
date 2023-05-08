using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dumpster : MonoBehaviour
{
    public Garbage.GarbageType type = Garbage.GarbageType.None;
    public GameObject particlesPrefab;
    public AudioSource CorrectSound;
    public GameObject badParticlesPrefab;
    public AudioSource IncorrectSound;
    public Transform particlesPivot;
    public DynamicTextData dynamicTextData;
    public DynamicTextData badDynamicTextData;


    void OnTriggerEnter(Collider other)
    {
        Garbage garbage = other.gameObject.GetComponent<Garbage>();
        if (garbage == null)
            return;
        GameObject particle = null;
        if (garbage.garbageType == type)
        {
            particle = Instantiate(particlesPrefab, particlesPivot.position, Quaternion.identity);
            ScoreBoard.Instance.UpdateScore(50);
            DynamicTextManager.CreateText(particlesPivot.position, "50", dynamicTextData);
            CorrectSound.Play();
        }
        else
        {
            particle = Instantiate(badParticlesPrefab, particlesPivot.position, Quaternion.identity);
            ScoreBoard.Instance.UpdateScore(-20);
            DynamicTextManager.CreateText(particlesPivot.position, "-20", badDynamicTextData);
            IncorrectSound.Play();
        }
        Destroy(particle, 1);
        Destroy(other.gameObject, 1);

    }
}
