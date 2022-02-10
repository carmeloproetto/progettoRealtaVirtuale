using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]

public class RisonanzaInteractable : Interactable
{
    public AudioClip impact;
    AudioSource audioSource;

    private CambiaCameraRisonanza ScriptCambiaCamera;
    public GameObject cameraRisonanza;

    public override void Interact(GameObject caller)
    {
        
        ScriptCambiaCamera.camRisonanzaOn = true;
        audioSource = GetComponent<AudioSource>();
        audioSource.PlayOneShot(impact, 0.7F);


        FindObjectOfType<AudioManager>().Play("BipCard");

    }

    public void Start()
    {
        ScriptCambiaCamera = cameraRisonanza.GetComponent<CambiaCameraRisonanza>();
    }

    // Update is called once per frame
    void Update()
    {
     //   Debug.Log(bool_script.open);
    }
}
