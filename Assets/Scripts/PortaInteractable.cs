using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortaInteractable : Interactable
{
    private Animator _animator;

    public override void Interact(GameObject caller)
    {
        bool opened = _animator.GetBool("Open");
        if (opened)
        {
            _animator.SetBool("Open", false);

            FindObjectOfType<AudioManager>().Play("Porta");
        }
        else _animator.SetBool("Open", true);

        FindObjectOfType<AudioManager>().Play("Porta");
    }

    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponentInParent<Animator>();
    }
}
