using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PorteAscensoreInteractable : Interactable
{
    private Animator _animator;

    public override void Interact(GameObject caller)
    {
        bool opened = _animator.GetBool("open");
        if (opened)
        {
            _animator.SetBool("open", false);
        }
        else _animator.SetBool("open", true);
    }

    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
    }
}

