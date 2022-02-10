using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothMovement : MonoBehaviour
{
    public float speed;
    private Vector3 destination;
    private bool arrived = false;
    public GameObject destObject; 


    // Start is called before the first frame update
    void Start()
    {
        SetDestination(gameObject.transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        if (destination != gameObject.transform.position)
        {
            IncrementPosition();
        }
        else if( destination == gameObject.transform.position && !arrived)
        {
            arrived = true;
            gameObject.transform.SetParent()
        }
    }

    void IncrementPosition()
    {
        // Calculate the next position
        float delta = speed * Time.deltaTime;
        Vector3 currentPosition = gameObject.transform.position;
        Vector3 nextPosition = Vector3.MoveTowards(currentPosition, destination, delta);

        // Move the object to the next position
        gameObject.transform.position = nextPosition;
    }

    public void SetDestination(Vector3 value)
    {
        destination = value;

    }
}
