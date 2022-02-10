using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TesseraGrabbable : Grabbable
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

        // this.transform.position = destination.transform.position; 
        // this.transform.SetParent(destination.transform);
        _movement.SetDestination(destination.transform.position);
    }

    protected override void Start()
    {
        _collider = GetComponent<Collider>();
        _movement = GetComponent<SmoothMovement>(); 
    }
}
