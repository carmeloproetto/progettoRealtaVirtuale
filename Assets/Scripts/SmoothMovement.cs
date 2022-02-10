using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothMovement : MonoBehaviour
{
    public float speed; 
    private bool moving = false;
    private bool arrived = false; 
    public GameObject destination; 


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if ( moving && !arrived && destination.transform.position != gameObject.transform.position )
        {
            IncrementPosition();
            if( gameObject.name == "Torcia"){
                IncrementRotation();
            }
            if( destination.transform.position == gameObject.transform.position)
            {
                arrived = true;
                moving = false;
                gameObject.transform.SetParent(destination.transform);
            }
        }
    }

    void IncrementPosition()
    {
        // Calculate the next position
        float delta = speed * Time.deltaTime;
        Vector3 currentPosition = gameObject.transform.position;
        Vector3 nextPosition = Vector3.MoveTowards(currentPosition, destination.transform.position, delta);
        

        // Move the object to the next position
        gameObject.transform.position = nextPosition;
    }

    void IncrementRotation()
    {
        // Calculate the next position
        float delta = speed * Time.deltaTime;

        Vector3 targetDirection = gameObject.transform.position - destination.transform.position;
        Vector3 newDirection = Vector3.RotateTowards(gameObject.transform.forward, targetDirection, delta, 0.0f);

        gameObject.transform.rotation = Quaternion.LookRotation(newDirection);
    }

    public void SetDestination(GameObject value)
    {
        destination = value;
    }

    public void SetMoving()
    {
        moving = true;
    }
}
