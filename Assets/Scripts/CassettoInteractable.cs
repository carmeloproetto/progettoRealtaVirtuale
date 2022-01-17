using System.Collections;
using UnityEngine;

public class CassettoInteractable : Interactable
{
    private Animator _animator;

    public override void Interact(GameObject caller)
    {
        bool opened = _animator.GetBool("Open");
        if (opened)
        {
            _animator.SetBool("Open", false);
        }
        else _animator.SetBool("Open", true);
    }

    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
    }
}
