using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Grabbable : MonoBehaviour
{
    protected Transform _originalParent;
    public Sprite icon; 

    public Transform OriginalParent
    {
        get => _originalParent;
        protected set => _originalParent = value; 
    }
    // Start is called before the first frame update
    protected virtual void Start()
    {
        _originalParent = transform.parent;
    }

    public abstract void Grab(GameObject grabber);
    public abstract void Drop();

    public abstract string GetDescription();

    public Sprite getImageIcon()
    {
        return icon;
    }
}
