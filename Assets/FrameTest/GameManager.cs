using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    static GameManager instance = null;
    public static GameManager Instance => instance;

    [Header("Button")]
    //public Button playButton;
    public Button restartButton;
    public Button restartButton2;
    public Button quitButton;
    public Button quitButton2;

    public GameObject gameOver;
    public GameObject victoryScreen;

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

        //if (playButton)
        //{
           // playButton.onClick.AddListener(() => Instance.ChangeScene("TestLevel"));
       // }
        //if (restartButton)
            restartButton.onClick.AddListener(() => Instance.ChangeScene("TestLevel"));
        //if (restartButton2)
            restartButton2.onClick.AddListener(() => Instance.ChangeScene("TestLevel"));

        //if (quitButton)
            quitButton.onClick.AddListener(Quit);
        //if (quitButton2)
            quitButton2.onClick.AddListener(Quit);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeScene(string sceneName)
    {
        Debug.Log("Eggbert");
        //SceneManager.LoadScene(sceneName);
    }

    private void Quit() //version specific code
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

    public void GameLost()
    {
        gameOver.SetActive(true);
    }

    public void GameWon()
    {
        victoryScreen.SetActive(true);
    }
}
