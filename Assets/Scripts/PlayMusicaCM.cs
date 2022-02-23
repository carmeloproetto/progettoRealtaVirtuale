using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayMusicaCM : MonoBehaviour
{
    public AudioSource s;
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            s.Play();
            Debug.Log("Play");
        }
    }
}
