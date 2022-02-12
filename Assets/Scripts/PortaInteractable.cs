using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortaInteractable : Interactable
{
    private Animator _animator;

    public bool doorLockedInTheMedicalCenter;


    public override void Interact(GameObject caller)
    {
        bool opened = _animator.GetBool("Open");
        if (opened == true && doorLockedInTheMedicalCenter == false)
        {           
                _animator.SetBool("Open", false);
            Debug.Log(doorLockedInTheMedicalCenter);
            //FindObjectOfType<AudioManager>().Play("Porta");
        }
        else if(opened == false && doorLockedInTheMedicalCenter == false)
                _animator.SetBool("Open", true);

         Debug.Log(doorLockedInTheMedicalCenter);
        FindObjectOfType<AudioManager>().Play("Porta");
    }

    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponentInParent<Animator>();
        doorLockedInTheMedicalCenter = true;
    }
}
