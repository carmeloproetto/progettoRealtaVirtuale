using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorchGrabbable : Grabbable
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
        this.transform.parent = destination.transform;

        Vector3 targetDirection = camera.transform.forward;
        Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, 1.0f, 0.0f);
        transform.rotation = Quaternion.LookRotation(newDirection);

        Debug.DrawRay(transform.position, transform.forward, Color.green);
    }

    protected override void Start ()
    {
        _rigidBody = GetComponent<Rigidbody>();
        _collider = GetComponent<Collider>();
    }
}
