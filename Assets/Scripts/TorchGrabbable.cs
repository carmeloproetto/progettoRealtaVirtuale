using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorchGrabbable : Grabbable
{
    public GameObject destination;
    public Camera camera; 
    private Collider _collider;
    private SmoothMovement _movement; 

    public override void Drop()
    {
        _collider.enabled = true;
    }

    public override void Grab(GameObject grabber)
    {
        _collider.enabled = false;
        _movement.SetMoving(); 

        //this.transform.SetPositionAndRotation(destination.transform.position, destination.transform.rotation);
    }

    protected override void Start ()
    {
        _collider = GetComponent<Collider>();
        _movement = GetComponent<SmoothMovement>(); 
    }
}
