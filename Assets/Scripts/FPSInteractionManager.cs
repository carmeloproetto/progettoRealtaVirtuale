using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

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

    public GameObject interactionUI;
    public TextMeshProUGUI interactionText;
    public Image icon;


    private bool hitSomething; 


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
        hitSomething = false;

        Vector3 rayOrigin = camera.transform.position + _fpsController.radius * camera.transform.forward;

        Ray ray = new Ray(rayOrigin, camera.transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, interactionDistance))
        {
            _pointingInteractable = hit.transform.GetComponent<Interactable>();
            if (_pointingInteractable)
            {
                hitSomething = true; 
                interactionText.text = _pointingInteractable.GetDescription();
                icon.overrideSprite = _pointingInteractable.getImageIcon(); 
                if (Input.GetMouseButtonDown(0))
                {
                    _pointingInteractable.Interact(gameObject);
                }
            }
            _pointingGrabbable = hit.transform.GetComponent<Grabbable>();
            if (_grabbedObject == null && _pointingGrabbable)
            {
                hitSomething = true;
                interactionText.text = _pointingGrabbable.GetDescription();
                icon.overrideSprite = _pointingGrabbable.getImageIcon();
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
        interactionUI.SetActive(hitSomething); 
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
