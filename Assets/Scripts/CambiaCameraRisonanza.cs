using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CambiaCameraRisonanza : MonoBehaviour
{
    public GameObject displayGioco;
   
    private Animator _animator;
    public bool StartAnimation;

    public Camera cameraPersonaggio;
    public Camera cameraRisonanza;
    public bool camRisonanzaOn;

    public float rotationSpeed = 8f;

    // Start is called before the first frame update
    void Start()
    {
         _animator = GetComponent<Animator>();
        camRisonanzaOn = false;
        StartAnimation = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(camRisonanzaOn){
            cameraPersonaggio.enabled = false;
            cameraRisonanza.enabled = true;
            if(StartAnimation = true){
                 _animator.SetBool("StartAnimation", true);
            }
            StartAnimation = true;
        }
    }



    //funzione che scatta al termine dell'animazione che ci porta dentro la risonanza
    public void startGameRisonanza(){
        displayGioco.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
    }
    
}
