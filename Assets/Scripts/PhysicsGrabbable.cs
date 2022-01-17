using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsGrabbable : Grabbable
{
    private Rigidbody _rigidbody;
    private Collider _collider;

    public override void Drop()
    {
        _collider.enabled = true;
        _rigidbody.isKinematic = false;
    }

    public override void Grab(GameObject grabber)
    {
        _collider.enabled = false;
        _rigidbody.isKinematic = true;
    }

    // Start is called before the first frame update
    protected override void Start ()
    {
        base.Start();
        _collider = GetComponent<Collider>();
        _rigidbody = GetComponent<Rigidbody>();
    }
}
