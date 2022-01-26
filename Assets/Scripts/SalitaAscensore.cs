using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SalitaAscensore : Interactable
{
    private Animator _animator;

    public override void Interact(GameObject caller)
    {
        bool opened = _animator.GetBool("up");
        if (opened)
        {
            _animator.SetBool("up", false);
        }
        else _animator.SetBool("up", true);
    }

    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
    }
}
