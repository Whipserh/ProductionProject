using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostMovement : MonoBehaviour
{

    public Transform[] patrolPoints;
    private int patrolIndex;
    public float stoppingDistance = 0.5f;
    public float speed = 3;
    void Start()
    {
        patrolIndex = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //check to see if we are near our destination, if we are then select the next point in the patrol.
        Vector3 destination = patrolPoints[patrolIndex].position;
        if(Vector3.Distance(transform.position, destination) <= stoppingDistance)
        {
            patrolIndex += (patrolIndex+1) % patrolPoints.Length;
            destination = patrolPoints[patrolIndex].position;
        }
        //movetowards next point
        Vector2 direction = (destination - transform.position).normalized;
        transform.Translate(direction * speed * Time.deltaTime);


    }
}
