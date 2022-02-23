using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortaInteractable : Interactable
{
    private Animator _animator;

    public bool doorLocked;

    public bool opened;

    public bool isTotalOpen;

    public override void Interact(GameObject caller)
    {

        if (opened && !doorLocked)
        {
            //chiusura porta
            Close();
            Debug.Log("Door Lock in portaInteractable: FALSE" + doorLocked + " " + opened);

        }
        else if (!opened && !doorLocked && FindObjectOfType<AudioMedicoManager>().inPlay == false)
            Open();

        Debug.Log("Door Lock in portaInteractable: " + doorLocked);
    }

    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponentInParent<Animator>();
        doorLocked = true;
        opened = _animator.GetBool("Open");
        isTotalOpen = false;
    }


    public void startWalkingNPC(){
      isTotalOpen = true;
      Debug.Log("porta aperta");
    }

    public void Open()
    {
        _animator.SetBool("Open", true);
        opened = true;
        FindObjectOfType<AudioManager>().Play("Porta");
    }

    public void Close()
    {
        _animator.SetBool("Open", false);
        opened = false;
        FindObjectOfType<AudioManager>().Play("Porta");
    }

    public void Lock()
    {
        doorLocked = true; 
    }

    public void Unlock()
    {
        doorLocked = false; 
    }

    public override string GetDescription()
    {
        return "PER APRIRE LA PORTA";
    }
}
