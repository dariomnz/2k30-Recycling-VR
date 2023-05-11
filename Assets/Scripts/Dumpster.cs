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
        GameObject particle = null;
        if (other.gameObject.name.Contains("SlingshotBase"))
        {
            particle = Instantiate(badParticlesPrefab, particlesPivot.position, Quaternion.identity);
            DynamicTextManager.CreateText(particlesPivot.position + (Vector3.up / 2), "IT'S NOT\n GARBAGE!", badDynamicTextData);
            IncorrectSound.Play();
            Destroy(particle, 1);
            return;
        }
        Garbage garbage = other.gameObject.GetComponent<Garbage>();
        if (garbage == null)
            return;
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
        Destroy(other.gameObject);

    }
}
