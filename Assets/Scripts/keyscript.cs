using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;


public class keyscript : MonoBehaviour
{

   // public static event Action OnPlayerDeath;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void OnTriggerEnter(Collider col)
    {

         if (col.gameObject.CompareTag("Player"))
            {
               // OnPlayerDeath?.Invoke();
                Debug.Log("Touched the key :)");
                Destroy(gameObject);
            }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
