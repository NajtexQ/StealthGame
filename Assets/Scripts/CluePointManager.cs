using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CluePointManager : MonoBehaviour
{
    public List<GameObject> cluePoints;
    public static CluePointManager instance;

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

        cluePoints[clueIndex].GetComponent<AudioSource>().Play();

        if (clueIndex < cluePoints.Count - 1)
        {
            cluePoints[clueIndex + 1].SetActive(true);
        }
    }
}
