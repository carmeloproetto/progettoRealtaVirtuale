using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PorteAscensoreInteractable : MonoBehaviour
{
    private Animator _animator;
    public bool open;
   
    public bool firstClose;
    
    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
        open = true;
        firstClose = true;
    }

    private void Update()
    {
        if (open)
            _animator.SetBool("open", false);
        else
            _animator.SetBool("open", true);
    }
}

