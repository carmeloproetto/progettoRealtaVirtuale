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

    public void SetDestination(GameObject value)
    {
        destination = value;
    }

    public void SetMoving()
    {
        moving = true;
    }
}
