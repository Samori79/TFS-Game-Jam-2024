using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] float moveSpeed = 2.5f;
    Rigidbody rb;

    Transform target;
    Vector3 moveDirection;

    //RaycastHit _hit;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        target = GameObject.Find("Player").transform;
        //target = target2;
    }

    // Update is called once per frame
    private void Update()
    {
        if(target)
        {
            Vector3 direction = (target.position - transform.position).normalized;
            //float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            //rb.rotation = Quaternion.Euler(0, 0, angle);
            moveDirection = direction;
        }
    }
     
    private void FixedUpdate()
    {
        if(target)
        {
            rb.velocity = new Vector3(moveDirection.x, moveDirection.y, moveDirection.z) * moveSpeed;
        }
    }

}
