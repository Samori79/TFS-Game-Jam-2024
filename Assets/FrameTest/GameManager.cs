using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    static GameManager instance = null;
    public static GameManager Instance => instance;

    // Start is called before the first frame update
    void Start()
    {
        if (instance)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadNextScene()
    {
        // Get the currently active scene
        Scene currentScene = SceneManager.GetActiveScene();

        // Check the name of the current scene
        if (currentScene.name == "Level1")
        {
            // Load Scene2 if Scene1 is currently active
            SceneManager.LoadScene("Level2");
        }
        else if (currentScene.name == "Level2")
        {
            // Load Scene3 if Scene2 is currently active
            SceneManager.LoadScene("Level3");
        }
        else if (currentScene.name == "Level3")
        {
            // Load Scene3 if Scene2 is currently active
            SceneManager.LoadScene("Level4");
        }
        else if (currentScene.name == "Level4")
        {
            // Load Scene3 if Scene2 is currently active
            SceneManager.LoadScene("Level5");
        }
        else if (currentScene.name == "Level5")
        {
            // Load Scene3 if Scene2 is currently active
            SceneManager.LoadScene("WinScreen");
        }
        // Add more conditions as needed for additional scenes
        else
        {
            // Default behavior if current scene is unknown or not relevant
            Debug.LogWarning("Unknown or irrelevant scene");
        }
    }
}


