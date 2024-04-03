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
    Rigidbody rb;
    bool onPath;

    Transform target;
    Vector3 moveDirection;
    //Ray _ray;
    RaycastHit _hit;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        target = GameObject.Find("Player").transform;
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
                if (Physics.Raycast(transform.position, direction, out _hit, sightLength))
                {
                    if (_hit.collider.gameObject.CompareTag("Player"))
                    {
                        Chase(direction);
                        return;
                    }
                }
            }
        }

        Walk();
    }

    private void FixedUpdate()
    {
        if(!onPath)
        { 
            rb.velocity = new Vector3(moveDirection.x, moveDirection.y, moveDirection.z) * moveSpeed;
        }
    }

    private void Walk()
    {
        onPath = true;
        rb.velocity = Vector3.zero;
    }

    private void Chase(Vector3 direction)
    {
        onPath = false;
        
        if (target)
        {           
            moveDirection = direction;
        }
    }

}