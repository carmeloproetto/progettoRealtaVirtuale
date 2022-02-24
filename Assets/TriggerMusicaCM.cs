using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerMusicaCM : MonoBehaviour
{
    public AudioSource s;
    public AudioSource s1;
    public AudioSource s2;
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            s.Stop();
            s1.Stop();
            s2.Stop();
            Debug.Log("Stop");
        }
    }
}