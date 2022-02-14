using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortaInteractable : Interactable
{
    private Animator _animator;

    public bool doorLockedInTheMedicalCenter;

    public bool opened;

    public bool isTotalOpen;

    public override void Interact(GameObject caller)
    {
        
        if (opened == true && doorLockedInTheMedicalCenter == false)
        {           
            //chiusura porta
            _animator.SetBool("Open", false);
            Debug.Log("Door Lock in portaInteractable: FALSE" + doorLockedInTheMedicalCenter);
            //FindObjectOfType<AudioManager>().Play("Porta");
        }
        else if(opened == false && doorLockedInTheMedicalCenter == false)
             _animator.SetBool("Open", true);
        opened = _animator.GetBool("Open");
        Debug.Log("Door Lock in portaInteractable: " +  doorLockedInTheMedicalCenter);
        FindObjectOfType<AudioManager>().Play("Porta");
    }

    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponentInParent<Animator>();
        doorLockedInTheMedicalCenter = true;
        opened = _animator.GetBool("Open");
        isTotalOpen = false;
    }


    public void startWalkingNPC(){
      isTotalOpen = true;
      Debug.Log("porta aperta");
    }

}
