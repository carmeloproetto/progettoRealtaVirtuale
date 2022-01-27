using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PorteAscensoreInteractable : Interactable
{
    private Animator _animator;
    public bool open;
    public override void Interact(GameObject caller)
    {
       // open = _animator.GetBool("open");
    }

    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
        open = false;
    }

    private void Update()
    {
        if (open)
            _animator.SetBool("open", false);
        else
            _animator.SetBool("open", true);
    }
}

