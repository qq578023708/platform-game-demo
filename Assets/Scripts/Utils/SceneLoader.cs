using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader
{
    public static void ReLoadScene()
    {
        int sceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(sceneIndex);
    }

    public static void QuitGame()
    {
    #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
    #else
        Application.Quit();
    #endif
    }

    public static void NextScene()
    {
        int sceneIndex = SceneManager.GetActiveScene().buildIndex+1;
        if (sceneIndex >= SceneManager.sceneCount)
        {
            ReLoadScene();
            return;
        }
        SceneManager.LoadScene(sceneIndex);
    }
}
