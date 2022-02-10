using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorchGrabbable : Grabbable
{
    public GameObject destination;
    public Camera camera; 
    private Collider _collider;

    public override void Drop()
    {
        _collider.enabled = true;
    }

    public override void Grab(GameObject grabber)
    {
        _collider.enabled = false;

        this.transform.SetPositionAndRotation(destination.transform.position, destination.transform.rotation);
        this.transform.SetParent(destination.transform);
    }

    protected override void Start ()
    {
        _collider = GetComponent<Collider>();
    }
}
