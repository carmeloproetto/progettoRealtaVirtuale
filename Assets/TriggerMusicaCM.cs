using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerMusicaCM : MonoBehaviour
{
    public AudioSource s;
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            s.Stop();
            Debug.Log("Stop");
        }
    }
}