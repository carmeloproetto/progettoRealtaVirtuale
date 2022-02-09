using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlideBed : Interactable
{
    // Start is called before the first frame update

    private Animator _animator;

    private bool slide = false;

    public override void Interact(GameObject caller)
    {
        slide = !slide;
    }

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (slide)
            _animator.SetBool("slide", true);
        else
            _animator.SetBool("slide", false);
    }
}
