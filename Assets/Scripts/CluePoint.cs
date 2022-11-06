using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CluePoint : MonoBehaviour
{

    public int clueIndex;
    private bool isTriggered = false;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (!isTriggered)
            {
                Debug.Log("Clue Entered");
                CluePointManager.instance.clueEntered(clueIndex);
                isTriggered = true;
            }
        }
    }

}
