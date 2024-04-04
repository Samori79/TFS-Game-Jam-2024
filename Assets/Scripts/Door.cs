using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class Door : MonoBehaviour
{

    private bool active = false;

    public PlayableDirector pd;
    // Start is called before the first frame update
    void Start()
    {
        keyscript.Unlock += Activate;

        pd = GetComponent<PlayableDirector>();


    }

    // Update is called once per frame
    void Update()
    {
        
    }

public void Activate()
    {
        active = !active;
        pd.Play();
        Debug.Log("door state changed");
        Invoke("SceneLoad", 1.4f);
    }

    public void SceneLoad()
    {
        GameManager.Instance.LoadNextScene();
    }
}
