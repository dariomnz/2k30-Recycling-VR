using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.XR.CoreUtils;
using UnityEngine.UI;

public class LevelSystem : MonoBehaviour
{
    public static LevelSystem Instance { get; private set; }

    public int currentLevel = -1;

    public List<float> scorePerLevel = new List<float>(){
        1000,2000,Mathf.Infinity
    };

    public GameObject Dumpsters;
    public GameObject TrashBins;

    public GameObject explosionPrefab;

    public GameObject tutorialText0;
    public GameObject tutorialText1;
    public GameObject tutorialText2;


    void Awake()
    {
        if (Instance != null && Instance != this)
            Destroy(this);
        else
            Instance = this;
    }

    void Start()
    {
        StartCoroutine(NextLevel());
    }

    public IEnumerator NextLevel()
    {
        RestartLevel();
        currentLevel += 1;
        LeanTween.cancel(gameObject);
        switch (currentLevel)
        {
            case 0:
                Dumpsters.SetActive(false);
                TrashBins.SetActive(true);
                tutorialText0?.SetActive(true);
                break;
            case 1:
                GetComponent<AudioSource>()?.Play();
                GameObject particle = null;
                foreach (Transform child in TrashBins.transform)
                {
                    particle = Instantiate(explosionPrefab, child.position + (Vector3.up / 2), Quaternion.identity);
                    Destroy(particle, 2);
                }
                yield return new WaitForSeconds(1);
                Dumpsters.SetActive(true);
                TrashBins.SetActive(false);
                tutorialText1?.SetActive(true);
                float prevPos = Dumpsters.transform.position.y;
                Vector3 pos = Dumpsters.transform.position;
                pos.y += 10;
                Dumpsters.transform.position = pos;
                LeanTween.moveY(Dumpsters, prevPos, 1).setEaseInSine();
                Vector3 prevScale = Dumpsters.transform.localScale;
                Dumpsters.transform.localScale = Vector3.zero;
                LeanTween.scale(Dumpsters, prevScale, 0.2f);
                break;
            case 2:
                GetComponent<AudioSource>()?.Play();
                particle = null;
                foreach (Transform child in Dumpsters.transform)
                {
                    particle = Instantiate(explosionPrefab, child.position + Vector3.up, Quaternion.identity);
                    Destroy(particle, 2);
                }
                yield return new WaitForSeconds(1);
                GameObject.FindFirstObjectByType<ToogleTips>().GetComponent<Toggle>().isOn = false;
                TipsSystem.Instance.ChangeTipsActive(false);
                Dumpsters.SetActive(true);
                TrashBins.SetActive(true);
                tutorialText2?.SetActive(true);
                prevPos = Dumpsters.transform.position.y;
                pos = Dumpsters.transform.position;
                pos.y += 10;
                Dumpsters.transform.position = pos;
                LeanTween.moveY(Dumpsters, prevPos, 1).setEaseInSine();
                prevScale = Dumpsters.transform.localScale;
                Dumpsters.transform.localScale = Vector3.zero;
                LeanTween.scale(Dumpsters, prevScale, 0.2f);
                prevPos = TrashBins.transform.position.y;
                pos = TrashBins.transform.position;
                pos.y += 10;
                TrashBins.transform.position = pos;
                LeanTween.moveY(TrashBins, prevPos, 1).setEaseInSine();
                prevScale = TrashBins.transform.localScale;
                TrashBins.transform.localScale = Vector3.zero;
                LeanTween.scale(TrashBins, prevScale, 0.2f);
                break;
            default:
                break;
        }
    }

    public bool CanChangeLevel(float actualScore)
    {
        return currentLevel < scorePerLevel.Count && actualScore > scorePerLevel[currentLevel];
    }

    void RestartLevel()
    {
        ScoreBoard.Instance.UpdateScore(-ScoreBoard.Instance.score);
        Dumpsters.SetActive(false);
        TrashBins.SetActive(false);
        tutorialText0?.SetActive(false);
        tutorialText1?.SetActive(false);
        tutorialText2?.SetActive(false);
        GameObject.FindFirstObjectByType<XROrigin>().transform.localPosition = Vector3.zero;
        GameObject.FindFirstObjectByType<XROrigin>().transform.localRotation = Quaternion.identity;
    }
}
