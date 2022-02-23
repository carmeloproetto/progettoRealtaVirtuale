using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerFreddoCabina : MonoBehaviour
{

    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            FindObjectOfType<AudioMedicoManager>().Play("Freddo");
            Collider collider = GetComponent<Collider>();
            collider.enabled = false; 
        }
    }
}
