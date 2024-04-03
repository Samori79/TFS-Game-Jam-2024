using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    public static event Action OnEnemyDeath;
    public static event Action OnPlayerDeath;
    private bool active = false;

    // Start is called before the first frame update
    void Start()
    {
        Trigger.Lever += Activate;
    }

    public void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("Enemy"))
        {
            OnEnemyDeath?.Invoke();
        }

        if (collider.gameObject.CompareTag("Player"))
        {
            OnPlayerDeath?.Invoke();
        }
    }

    public void Activate()
    {
        active = !active;
    }
}
