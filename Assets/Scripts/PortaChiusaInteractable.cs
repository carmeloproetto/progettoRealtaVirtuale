using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortaChiusaInteractable : Interactable
{
    private Animator _animator;
    public GameObject uiInteraction;

    public override string GetDescription()
    {
        uiInteraction.SetActive(true);
        return "PER INTERAGIRE";
    }

    public override void Interact(GameObject caller)
    {
        _animator.SetTrigger("Apri");

        FindObjectOfType<AudioManager>().Play("PortaBloccata");
    }

    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
    }
}
