using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CluePointManager : MonoBehaviour
{
    public List<GameObject> cluePoints;
    public static CluePointManager instance;
    public GameObject endScreen;

    private bool hasKey = false;

    void Awake()
    {
        instance = this;

        foreach (GameObject cluePoint in cluePoints)
        {
            CluePoint cluePointComponent = cluePoint.GetComponent<CluePoint>();
            cluePointComponent.clueIndex = cluePoints.IndexOf(cluePoint);
            Debug.Log("Clue Index: " + cluePointComponent.clueIndex);
            cluePoint.SetActive(false);
        }
        cluePoints[0].SetActive(true);
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void clueEntered(int clueIndex)
    {

        AudioSource audioSource = cluePoints[clueIndex].GetComponent<AudioSource>();
        audioSource.Play();
        Debug.Log("Clue Entered: " + clueIndex);
        Debug.Log("Playing Audio: " + audioSource.clip.name);

        if (cluePoints[clueIndex].GetComponent<CluePoint>().giveKey)
        {
            hasKey = true;
        }

        if (clueIndex < cluePoints.Count - 1)
        {
            cluePoints[clueIndex + 1].SetActive(true);
        }
        else
        {
            if (hasKey)
            {
                StartCoroutine(waitForAudio(audioSource));
                Time.timeScale = 0;
                endScreen.SetActive(true);
            }
            else
            {
                AudioSource failAudio = this.GetComponent<AudioSource>();
                failAudio.Play();
                StartCoroutine(waitForAudio(failAudio));
            }
        }
    }

    IEnumerator waitForAudio(AudioSource audioSource)
    {
        yield return new WaitForSeconds(audioSource.clip.length);
    }
}
