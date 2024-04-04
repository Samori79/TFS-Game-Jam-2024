using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class Trap : MonoBehaviour
{
    public static event Action OnEnemyDeath;
    public static event Action OnPlayerDeath;
    private bool active = false;

    public PlayableDirector playableDirector;

    // Start is called before the first frame update
    void Start()
    {
        Trigger.Lever += Activate;

        playableDirector = GetComponent<PlayableDirector>();
    }

    private void Update()
    {
        if (active)
        {
            playableDirector.Play();
        }
    }

    public void OnTriggerEnter(Collider collider)
    {
        if (active)
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
    }

    public void Activate()
    {
        active = !active;
        Debug.Log("trap state changed");
    }
}
