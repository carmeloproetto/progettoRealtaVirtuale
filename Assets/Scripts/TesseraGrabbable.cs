using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TesseraGrabbable : Grabbable
{
    public Camera camera;
    private Collider _collider;
    private SmoothMovement _movement; 

    public override void Drop()
    {
        Destroy(gameObject); 
    }

    public override void Grab(GameObject grabber)
    {
        _collider.enabled = false;
        _movement.SetMoving();

        FindObjectOfType<AudioManager>().Play("Grab");
    }

    protected override void Start()
    {
        _collider = GetComponent<Collider>();
        _movement = GetComponent<SmoothMovement>(); 
    }
}
