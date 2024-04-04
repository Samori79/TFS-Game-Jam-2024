using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;


public class Trigger : MonoBehaviour
{

    public PlayableDirector pd;

    Transform playerRef;
    public static event Action Lever;
    public float activationRange = 3.0f;

    // Start is called before the first frame update
    void Start()
    {
        playerRef = GameObject.FindGameObjectWithTag("Player").transform;
        if (!playerRef)
            Debug.Log("Lever cannot find the player T.T");


            pd = GetComponent<PlayableDirector>();

        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump") && Vector3.Distance(transform.position, playerRef.position) <= activationRange)
        {
            Lever?.Invoke();
            Debug.Log("lever pulled");


        //on trigger activate, play animation :)
            pd.Play();

        }
    }
}

