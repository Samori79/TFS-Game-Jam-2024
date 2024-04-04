using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;

    public Rigidbody rb;
    public Animator animator;

    Vector3 movement;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

         Trap.OnPlayerDeath += Death;
         

    }

    // Update is called once per frame
    void Update()
    {
     float horizontalInput = Input.GetAxisRaw("Horizontal");
     float verticalInput = Input.GetAxisRaw("Vertical");

      // Construct the movement vector
       movement = new Vector3(horizontalInput, 0f, verticalInput).normalized;


       animator.SetFloat("Horizontal", movement.x);
       animator.SetFloat("Vertical", movement.z);
       animator.SetFloat("Speed", movement.sqrMagnitude);
    }

    void FixedUpdate()
    {
    //movement
    rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);


    }

      private void Death()
    {
        moveSpeed = 0f;
        animator.SetTrigger("Death");
        Debug.Log("Player has fallen :(");
        Destroy(gameObject, 1.5f);
    }

}
