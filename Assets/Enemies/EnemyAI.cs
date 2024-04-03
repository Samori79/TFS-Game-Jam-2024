using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.EventSystems;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5.0f;
    [SerializeField] float sightLength = 10.0f;
    [SerializeField] float fov = 10f;
    [SerializeField] Transform marker1;
    [SerializeField] Transform marker2;
    Rigidbody rb;
    bool headedTo1 = false;
    private DateTime lastCalledTime;
    TimeSpan threshold;
    Transform target;
    Vector3 moveDirection;
    RaycastHit _hit;
    bool pause = false;
    bool isInSearchingState;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        target = GameObject.Find("Player").transform;
        //lastCalledTime = DateTime.Now;
        if (!marker1 || !marker2)
            Debug.Log("Pathfinding transforms are missing on " + gameObject.name);
        threshold = TimeSpan.FromSeconds(2);
    }

    private void Update()
    {
        if (Vector3.Distance(target.position, transform.position) < sightLength)
        {
            Vector3 direction = (target.position - transform.position).normalized;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

            // Calculate the angle between the direction to the target and the forward direction of the object
            float angleDifference = Mathf.DeltaAngle(angle, transform.eulerAngles.z);

            // Check if the angle difference is within the desired range
            if (Mathf.Abs(angleDifference) <= fov)
            {
                // Perform a raycast in the direction of the target
                if (Physics.Raycast(transform.position, direction, out _hit))
                {
                    if (_hit.collider.gameObject.CompareTag("Player"))
                    {
                        Chase(direction);
                        return;
                    }
                }
            }
        }

        // Introduce a buffer or hysteresis to prevent rapid state switching
        if (!isSearching(threshold))
        {
            Walk();
        }
        else
        {
            // Only transition to searching state if not already in searching state
            if (!isInSearchingState)
            {
                Searching();
                isInSearchingState = true; // Set flag to indicate that we're in searching state
            }
        }

        // Reset flag when not in searching state
        if (isInSearchingState && isSearching(threshold))
        {
            isInSearchingState = false;
        }
    }


    //private void Update()
    //{
    //    if (Vector3.Distance(target.position, transform.position) < sightLength)
    //    {
    //        Vector3 direction = (target.position - transform.position).normalized;
    //        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

    //        // Calculate the angle between the direction to the target and the forward direction of the object
    //        float angleDifference = Mathf.DeltaAngle(angle, transform.eulerAngles.z);

    //        // Check if the angle difference is within the desired range
    //        if (Mathf.Abs(angleDifference) <= fov)
    //        {
    //            // Perform a raycast in the direction of the target
    //            if (Physics.Raycast(transform.position, direction, out _hit))
    //            {
    //                if (_hit.collider.gameObject.CompareTag("Player"))
    //                {
    //                    Chase(direction);
    //                    return;
    //                }
    //            }
    //        }
    //    }
    //    if (!isSearching(threshold))
    //    {
    //        Walk();
    //    }
    //    else
    //    {
    //        Searching();
    //    }
    //}

    private void FixedUpdate()
    {
        if(!pause)
        {
            rb.velocity = new Vector3(moveDirection.x, moveDirection.y, moveDirection.z) * moveSpeed;
        }
    }

    private void Walk()
    {
        pause = false;
        //Debug.Log("Walk is called");
        if (!headedTo1)
        {
            Vector3 walkTo2 = (marker2.position - transform.position).normalized;
            moveDirection = walkTo2;

            if (Vector3.Distance(marker2.position, transform.position) < 0.2f)
            {
                headedTo1 = true;
            }
        }
        if(headedTo1)
        {
            Vector3 walkTo1 = (marker1.position - transform.position).normalized;
            moveDirection = walkTo1;
            {
                if (Vector3.Distance(marker1.position, transform.position) < 0.2f)
                {
                    headedTo1 = false;
                }
            }
        }   
    }

    private void Chase(Vector3 direction)
    {
        pause = false;
        Debug.Log("Chase is called");
        if (target)
        {           
            moveDirection = direction;
        }
        lastCalledTime = DateTime.Now;
    }

    bool isSearching(TimeSpan timeThreshold)
    {
        // Check if the time elapsed since the last function call is less than the given threshold
        return (DateTime.Now - lastCalledTime) < timeThreshold;
    }

    private void Searching()
    {
        pause = true;
        rb.velocity = Vector3.zero;
        Debug.Log("Searching is called");
    }
}