using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayMusicaCM : MonoBehaviour
{
    public AudioSource s;
    public AudioSource s1;
    public AudioSource s2;
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            s.Play();
            s1.Play();
            s2.Play();
            Debug.Log("Play");
        }
    }
}
