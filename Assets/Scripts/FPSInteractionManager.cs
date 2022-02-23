using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;

public class FPSInteractionManager : MonoBehaviour
{
    public float interactionDistance; 
    private CharacterController _fpsController;
    public Camera camera;

    public Image _target;

    private Grabbable _pointingGrabbable;
    private Interactable _pointingInteractable;

    private Grabbable _grabbedObject;
    public bool duringTask;


    // Start is called before the first frame update
    void Start()
    {
        _fpsController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    { 
        CheckInteraction(); 

        if( _grabbedObject != null && Input.GetMouseButtonDown(1) && !duringTask)
        {
            Drop(); 
        }

        UpdateUITarget();
    }

    private void CheckInteraction()
    {
        Vector3 rayOrigin = camera.transform.position + _fpsController.radius * camera.transform.forward;

        Ray ray = new Ray(rayOrigin, camera.transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, interactionDistance))
        {
            _pointingInteractable = hit.transform.GetComponent<Interactable>();
            if (_pointingInteractable)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    _pointingInteractable.Interact(gameObject);
                }
            }
            _pointingGrabbable = hit.transform.GetComponent<Grabbable>();
            if (_grabbedObject == null && _pointingGrabbable)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    _pointingGrabbable.Grab(gameObject);
                    Grab(_pointingGrabbable);
                }
            }
            Debug.DrawRay(rayOrigin, camera.transform.forward * interactionDistance, Color.red);
        }
        else
        {
            _pointingGrabbable = null;
            _pointingInteractable = null;
        }
    }

    private void Grab(Grabbable grabbable)
    {
        _grabbedObject = grabbable;
        _grabbedObject.transform.SetParent(camera.transform);
    }

    private void Drop()
    {
        if(_grabbedObject == null)
        {
            return; 
        }
        _grabbedObject.transform.parent = _grabbedObject.OriginalParent;
        _grabbedObject.Drop();
        _grabbedObject = null;
    }

    private void UpdateUITarget()
    {
        if (_pointingInteractable)
            _target.color = Color.green;
        else if (_pointingGrabbable)
            _target.color = Color.yellow;
        else
            _target.color = Color.red;
    }

    public Grabbable grabbedObject()
    {
        return _grabbedObject; 
    }

    public void setDuringTask(bool value)
    {
        duringTask = value; 
    }

}
