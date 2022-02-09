using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TesseraGrabbable : Grabbable
{
    public GameObject destination;
    public Camera camera;
    private Rigidbody _rigidBody;
    private Collider _collider;

    public override void Drop()
    {
        _collider.enabled = true;
        _rigidBody.isKinematic = false;
    }

    public override void Grab(GameObject grabber)
    {
        _collider.enabled = false;
        _rigidBody.isKinematic = true;

        this.transform.position = destination.transform.position; 
        this.transform.SetParent(destination.transform);
    }

    protected override void Start()
    {
        _rigidBody = GetComponent<Rigidbody>();
        _collider = GetComponent<Collider>();
    }
}
