using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerMare : MonoBehaviour
{

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            FindObjectOfType<AudioManager>().StopPlaying("Mare");
            Debug.Log("StopMare");
        }
    }
}
