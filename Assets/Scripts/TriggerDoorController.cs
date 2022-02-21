using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDoorController : MonoBehaviour
{
    [SerializeField] private PortaInteractable door;

    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            Debug.Log("Collision Detected"); 
            if(door.opened)
            {
                door.Close();
                door.doorLocked = true; 
                gameObject.SetActive(false);
                //FindObjectOfType<AudioMedicoManager>().Play("Freddo");
            }
        }
    }
}
