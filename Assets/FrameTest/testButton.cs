using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class testButton : MonoBehaviour
{
    // Start is called before the first frame update

    public void StartGame()
    {
        Debug.Log("LoadGaem");
        SceneManager.LoadScene("TestLevel");
    }

    public void Quit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
